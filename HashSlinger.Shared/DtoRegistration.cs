namespace HashSlinger.Shared;

using System.Net;
using System.Reflection;
using Mapster;

/// <inheritdoc />

// ReSharper disable once UnusedType.Global
public class DtoRegistration : ICodeGenerationRegister
{
    /// <inheritdoc />
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto", MapType.Map | MapType.MapToTarget | MapType.Projection)
            .ForAllTypesInNamespace(Assembly.GetAssembly(typeof(DtoRegistration))!, "HashSlinger.Shared.Models")
            .ExcludeTypes(type => type.IsEnum)
            .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
            .AlterType<IPAddress, string>()
            .IgnoreNullValues(true)
            .MaxDepth(2);
    }
}
