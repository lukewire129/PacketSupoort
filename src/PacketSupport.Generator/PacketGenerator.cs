using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PacketSupport.Generator
{
    [Generator]
    public class PacketGenerator : IIncrementalGenerator
    {
        private const string AttributeSource = @"
namespace PacketSupport.Generator.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class PacketAttribute : System.Attribute
    {
    }
}";
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Attribute를 소스 코드로 추가
            context.RegisterPostInitializationOutput (ctx =>
            {
                ctx.AddSource ("PacketAttribute.g.cs", SourceText.From (AttributeSource, Encoding.UTF8));
            });

            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch ();
            //}
            // 1. 클래스 선언에서 [PacketGenerator]가 적용된 클래스 탐지
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
                   classDeclaration.AttributeLists.Any (attr => attr.Attributes.Any (a => a.Name.ToString () == "Packet"));
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
            var attribute = classSymbol.GetAttributes ().FirstOrDefault (a => a.AttributeClass?.Name == "PacketAttribute");
            if (attribute == null)
                return string.Empty;

            // 클래스 및 Enum 이름 추출
            var namespaceName = classSymbol.ContainingNamespace.ToDisplayString ();
            var className = classSymbol.Name;

            // 코드 생성
            return $@"
using System;

namespace {namespaceName}
{{
    public partial class {className}
    {{
       public static {className} Serialize(byte[] data)
       {{
          return BytePacketSupport.PacketParse.Serialize<{className}>(data);
       }}

       public byte[] Deserialize()
       {{
          return BytePacketSupport.PacketParse.Deserialize<{className}>(data);
       }}
    }}
}}
";
        }
    }
}
