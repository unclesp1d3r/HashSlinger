namespace HashSlinger.Api;

using System.Reflection;
using Mapster;

/// <inheritdoc />
public class DtoRegistration : ICodeGenerationRegister
{
    /// <inheritdoc />
    public void Register(CodeGenerationConfig config)
    {
        TypeAdapterConfig.GlobalSettings.EnableJsonMapping();
        TypeAdapterConfig.GlobalSettings.Default.IgnoreNullValues(true);
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "HashSlinger.Api.Models")
            .MaxDepth(1)
            .IgnoreNullValues(true);
    }
}
