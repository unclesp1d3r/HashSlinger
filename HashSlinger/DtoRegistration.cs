namespace HashSlinger.Api;

using System.Reflection;
using Mapster;

/// <inheritdoc />
public class DtoRegistration : ICodeGenerationRegister
{
    /// <inheritdoc />
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "HashSlinger.Api.Models");
    }
}
