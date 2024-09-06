using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BytePacketSupportCore 
{
    [Generator]
    public class EnumFlagGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            // Attribute를 소스 코드로 추가
            context.RegisterPostInitializationOutput (ctx =>
            {
                ctx.AddSource ("BitSupportFlagsAttribute.g.cs", SourceText.From (AttributeSource, Encoding.UTF8));
            });

            // Enum과 속성을 찾기 위한 증분 처리
            var enumDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider (
                    predicate: IsEnumWithBitSupportFlagsAttribute,
                    transform: GetEnumSemanticModel)
                .Where (enumModel => enumModel != null);

            // Enum 정보를 기반으로 소스 코드 생성
            context.RegisterSourceOutput (enumDeclarations, (spc, enumModel) =>
            {
                if (enumModel is not null)
                {
                    var source = GenerateEnumFlags (enumModel);
                    spc.AddSource ($"{enumModel.Name}Flags.g.cs", SourceText.From (source, Encoding.UTF8));
                }
            });
        }

        // [BitSupportFlags] 속성이 적용된 enum을 식별하는 메서드
        private static bool IsEnumWithBitSupportFlagsAttribute(SyntaxNode node, CancellationToken ct)
        {
            return node is EnumDeclarationSyntax enumDeclaration &&
                   enumDeclaration.AttributeLists
                       .Any (al => al.Attributes
                           .Any (a => a.Name.ToString () == "BitSupportFlags"));
        }

        // SemanticModel을 가져오는 메서드로, enum 정보를 수집
        private static EnumModel GetEnumSemanticModel(GeneratorSyntaxContext context, CancellationToken ct)
        {
            var enumDeclaration = (EnumDeclarationSyntax)context.Node;
            var enumSymbol = context.SemanticModel.GetDeclaredSymbol (enumDeclaration);

            if (enumSymbol == null)
                return null;

            return new EnumModel
            {
                Name = enumSymbol.Name,
                Namespace = enumSymbol.ContainingNamespace.ToString (),
                Members = enumDeclaration.Members.Select ((member, index) => new EnumMember
                {
                    Name = member.Identifier.Text,
                    Value = 1 << index // 각 멤버의 비트값을 계산
                }).ToList ()
            };
        }

        // 소스 코드를 생성하는 메서드
        private static string GenerateEnumFlags(EnumModel enumModel)
        {
            var members = string.Join ("\n", enumModel.Members.Select (m => $"    {m.Name} = {m.Value},"));

            return $@"
namespace {enumModel.Namespace}
{{
    [System.Flags]
    public enum {enumModel.Name}Flags
    {{
{members}
    }}
}}";
        }

        private const string AttributeSource = @"
namespace System
{
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class BitSupportFlagsAttribute : System.Attribute
    {
    }
}";

        // enum 정보 모델
        private class EnumModel
        {
            public string Name { get; set; }
            public string Namespace { get; set; }
            public List<EnumMember> Members { get; set; }
        }

        // enum 멤버 정보 모델
        private class EnumMember
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}
