namespace HashSlinger.Api;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Mapster;

/// <inheritdoc />

// ReSharper disable once UnusedType.Global
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class DtoRegistration : ICodeGenerationRegister
{
    /// <inheritdoc />
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto").ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "HashSlinger.Api.Models");
    }
}
