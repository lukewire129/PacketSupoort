using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitSupport.SourceGenerators.Generator
{
    [Generator]
    public class ClassEnumFlagGenerator : IIncrementalGenerator
    {
        private const string AttributeSource = @"
namespace BitSupport.SourceGenerators.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class BitStateAttribute : System.Attribute
    {
        public Type StateEnumType { get; }

        public BitStateAttribute(Type stateEnumType)
        {
            StateEnumType = stateEnumType;
        }
    }
}";

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Attribute를 소스 코드로 추가
            context.RegisterPostInitializationOutput (ctx =>
            {
                ctx.AddSource ("BitStateAttribute.g.cs", SourceText.From (AttributeSource, Encoding.UTF8));
            });

            // 1. 클래스 선언에서 [StateGenerator]가 적용된 클래스 탐지
            var classDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider (
                    predicate: (s, _) => IsClassWithAttribute (s),
                    transform: (ctx, _) => GetClassSemanticModel (ctx))
                .Where (c => c != null);

            // 2. 각 클래스에 대해 코드를 생성
            context.RegisterSourceOutput (classDeclarations, (ctx, classSymbol) =>
            {
                var namedTypeSymbol = classSymbol as INamedTypeSymbol;
                if (namedTypeSymbol == null)
                    return;

                // 생성된 코드 작성
                var source = GenerateStateMethods (namedTypeSymbol);
                ctx.AddSource (namedTypeSymbol.Name + "StateMethods.g.cs", SourceText.From (source, Encoding.UTF8));
            });
        }

        private bool IsClassWithAttribute(SyntaxNode syntaxNode)
        {
            return syntaxNode is ClassDeclarationSyntax classDeclaration &&
                   classDeclaration.AttributeLists.Any (attr => attr.Attributes.Any (a => a.Name.ToString () == "BitState"));
        }

        private INamedTypeSymbol GetClassSemanticModel(GeneratorSyntaxContext context)
        {
            var classDeclaration = (ClassDeclarationSyntax)context.Node;
            var model = context.SemanticModel.GetDeclaredSymbol (classDeclaration);
            return model as INamedTypeSymbol;
        }

        private static string GenerateStateMethods(INamedTypeSymbol classSymbol)
        {
            // Attribute에서 Enum 타입 가져오기
            var attribute = classSymbol.GetAttributes ().FirstOrDefault (a => a.AttributeClass?.Name == "BitStateAttribute");
            if (attribute == null)
                return string.Empty;

            var enumType = attribute.ConstructorArguments[0].Value as INamedTypeSymbol;
            if (enumType == null)
                return string.Empty;

            // 전달된 타입이 Enum인지 확인
            if (enumType.TypeKind != TypeKind.Enum)
                throw new InvalidOperationException ($"{enumType.Name}은 Enum 타입이 아닙니다.");

            // [Flags] 특성 확인
            var hasFlagsAttribute = enumType.GetAttributes ().Any (attr => attr.AttributeClass?.ToDisplayString () == "System.FlagsAttribute");
            if (!hasFlagsAttribute)
                throw new InvalidOperationException ($"{enumType.Name}은 [Flags] 특성이 없습니다.");

            // 클래스 및 Enum 이름 추출
            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString ();
            var className = classSymbol.Name;
            var enumName = enumType.Name;

            // 코드 생성
            return $@"
using System;

namespace {namespaceName}
{{
    public partial class {className}
    {{
        private byte tempByte;
        private {enumName} _currentState;

        public void SetState({enumName} state)
        {{
            _currentState |= state;
            tempByte = _currentState.ToByte ();
        }}

        public void RemoveState({enumName} state)
        {{
            if ((_currentState & state) == state)
            {{
                _currentState &= ~state;
            }}
            tempByte = _currentState.ToByte ();
        }}

        public bool IsState({enumName} state)
        {{
            return (_currentState & state) == state;
        }}

        public byte GetByte()
        {{
            return tempByte;
        }}
    }}
}}
";
        }
    }
    public class ClassWithStateSyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Candidates { get; } = new List<ClassDeclarationSyntax> ();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDecl &&
                classDecl.AttributeLists.Any (attr => attr.Attributes.Any (a => a.Name.ToString () == "StateGenerator")))
            {
                Candidates.Add (classDecl);
            }
        }
    }
}
