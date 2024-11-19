using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BitSupport.SourceGenerators.Generator
{
    [Generator]
    public class EnumFlagGenerator : IIncrementalGenerator
    {
        private const string AttributeSource = @"
namespace BitSupport.SourceGenerators.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Enum)]
    public class BitSupportFlagsAttribute : System.Attribute
    {
    }
}";

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
                if (enumModel != null)
                {
                    var source = GenerateEnumFlags (enumModel);
                    spc.AddSource ($"{enumModel.Name}Flags.g.cs", SourceText.From (source, Encoding.UTF8));
                }

                if (enumModel != null)
                {
                    var source = GenerateEnumFlagsExtentions (enumModel);
                    spc.AddSource ($"{enumModel.Name}FlagsExtentions.g.cs", SourceText.From (source, Encoding.UTF8));
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
                Members = enumDeclaration.Members.Select ((member, index) =>
                {
                    bool isNoneField = enumDeclaration.Members.Any (x => x.Identifier.Text.ToUpper () == "NONE");
                    if (isNoneField && member.Identifier.Text.ToUpper () == "NONE")
                    {
                        return new EnumMember
                        {
                            Name = member.Identifier.Text,
                            Value = 0
                        };
                    }
                    return new EnumMember
                    {
                        Name = member.Identifier.Text,
                        Value = isNoneField ? (index - 1) : index // 각 멤버의 비트값을 계산
                    };
                }).ToList ()
            };
        }

        // 소스 코드를 생성하는 메서드
        private static string GenerateEnumFlags(EnumModel enumModel)
        {
            if (enumModel.Members.FirstOrDefault (x => x.Name.ToUpper () == "NONE") == null)
            {
                enumModel.Members.Insert (0, new EnumMember ()
                {
                    Name = "NONE",
                    Value = 0
                });
            }
            List<string> memberString = new List<string> ();
            foreach (var member in enumModel.Members)
            {
                if (member.Name.ToUpper () == "NONE")
                {
                    memberString.Add ("          NONE,");
                    continue;
                }
                memberString.Add ($"          {member.Name} = 1 << {enumModel.Namespace}.{enumModel.Name}.{member.Name},");
            }

            var members = string.Join ("\n", memberString);

            return $@"namespace {enumModel.Namespace}
{{
    [System.Flags]
    public enum {enumModel.Name}Flags
    {{
{members}
    }}
}}";
        }

        // 소스 코드를 생성하는 메서드2
        private static string GenerateEnumFlagsExtentions(EnumModel enumModel)
        {
            var FlagsName = $"{enumModel.Namespace}.{ enumModel.Name }Flags";
            return $@"namespace {enumModel.Namespace}
{{
    public static class {enumModel.Name}FlagsExtensions
    {{
        public static {FlagsName} ToFlags(this {enumModel.Namespace}.{enumModel.Name} d) => ({FlagsName})(1 << (int)d);

        // 여러 플래그가 모두 설정되었는지 확인 
        public static bool HasFlags(this {FlagsName} value, {FlagsName} flags) => (Convert.ToByte (value) & Convert.ToByte (flags)) == Convert.ToByte (flags);

        // 여러 플래그 중 하나라도 설정되었는지 확인
        public static bool HasAnyFlag(this {FlagsName} value, {FlagsName} flags) => (value & flags) != 0;

        // 플래그가 설정되지 않았는지 확인
        public static bool HasNotFlag(this {FlagsName} value, {FlagsName} flags) => (value & flags) == 0;

        // 여러 플래그 중 하나라도 설정되었는지 확인
        public static bool HasAnyFlag(this {FlagsName} value, {enumModel.Namespace}.{enumModel.Name} d) => (value & ({FlagsName})(1 << (int)d)) != 0;

        // 플래그가 설정되지 않았는지 확인
        public static bool HasNotFlag(this {FlagsName} value, {enumModel.Namespace}.{enumModel.Name} d) => (value & ({FlagsName})(1 << (int)d)) == 0;

        // ToEnum Mode 1
        public static {FlagsName} ToEnum<T> (this byte byteValue) where T : Enum
        {{
            var enumType = typeof(T);
            
            if(enumType.Name == ""{enumModel.Name}Flags"")
                return ({FlagsName})Enum.ToObject (typeof(T), byteValue);
                
            var attributes = enumType.GetCustomAttributes(false);
            string attributeName = ""BitSupportFlagsAttribute"";
            bool hasAttribute = attributes.Any(attr => attr.GetType().Name == attributeName);
            if (hasAttribute)
            {{
                string flagsEnumName = $""{{enumType.Name}}Flags"";
                var assembly = enumType.Assembly;
                var flagsEnumType = assembly.GetType(enumType.Namespace + ""."" + flagsEnumName);
                if (flagsEnumType != null && flagsEnumType.IsEnum)
                {{
                    var flagsEnumValue = Enum.ToObject(flagsEnumType, byteValue);
                    return ({FlagsName})flagsEnumValue;                
                }}
            }}

            throw new InvalidOperationException ($""Enum type '{FlagsName}' not found."");
        }}        

        public static byte ToByte(this Enum enumValue)
        {{
            return Convert.ToByte (enumValue);
        }}
    }}
}}";
        }

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
