namespace HashSlinger.Api.Endpoints.ClientApiV1.Handlers;

using MediatR;
using Services;

/// <summary>Represents a query to get a file by name</summary>

// ReSharper disable once ClassNeverInstantiated.Global
public record GetFileByNameQuery(string Bucket, string Name) : IRequest<Stream?>;

/// <summary>Handles getting a file by name</summary>

// ReSharper disable once UnusedMember.Global
// ReSharper disable once UnusedType.Global
public class GetFileByNameHandler : IRequestHandler<GetFileByNameQuery, Stream?>
{
    private readonly IFileStorageService _fileStorageService;

    /// <summary>Initializes a new instance of the <see cref="GetFileByNameHandler" /> class.</summary>
    /// <param name="fileStorageService">The file storage service.</param>
    public GetFileByNameHandler(IFileStorageService fileStorageService) =>
        _fileStorageService = fileStorageService;

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<Stream?> Handle(GetFileByNameQuery request, CancellationToken cancellationToken)
    {
        Stream? file = await _fileStorageService.GetFileAsync(request.Name, request.Bucket).ConfigureAwait(true);
        return file;
    }
}
