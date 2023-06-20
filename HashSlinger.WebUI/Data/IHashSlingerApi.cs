namespace HashSlinger.WebUI.Data;

using HashSlinger.Shared.Generated;
using Refit;

public interface IHashSlingerApi
{
    [Post("/api/v1/Agent")] public Task<AgentDto> CreateAgentAsync(AgentDto agent);
    [Delete("/api/v1/Agent/{id}")] public Task DeleteAgentAsync(int id);
    [Get("/api/v1/Agent/{id}")] public Task<AgentDto> GetAgentAsync(int id);
    [Get("/api/v1/Agent")] public Task<List<AgentDto>> GetAllAgentsAsync();
    [Put("/api/v1/Agent/{id}")] public Task UpdateAgentAsync(int id, AgentDto agent);
}
