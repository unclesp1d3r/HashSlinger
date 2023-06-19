namespace HashSlinger.Shared;

using System.Reflection;
using Mapster;

/// <inheritdoc />

// ReSharper disable once UnusedType.Global
public class DtoRegistration : ICodeGenerationRegister
{
    /// <inheritdoc />
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForAllTypesInNamespace(Assembly.GetAssembly(typeof(DtoRegistration))!, "HashSlinger.Shared.Models");
    }
}
