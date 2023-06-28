namespace HashSlinger.WebUI.Data;

using HashSlinger.Shared.Generated;
using HashSlinger.Shared.Models;
using Refit;
using Task = System.Threading.Tasks.Task;

public interface IHashSlingerApi
{
    [Post("/Agent")] public Task<AgentDto> CreateAgentAsync(AgentDto agent);

    [Post("/AgentBinaries")] public Task<AgentBinaryDto> CreateAgentBinaryAsync(AgentBinaryDto agentBinary);

    [Post("/CrackerBinary")] public Task<CrackerBinaryDto> CreateCrackerBinaryAsync(CrackerBinaryDto crackerBinary);
    [Post("/Hashlist")] public Task<HashlistDto> CreateHashlistAsync(HashlistDto hashlist);

    [Post("/RegistrationVoucher")]
    public Task<int> CreateRegistrationVoucherAsync(RegistrationVoucherDto voucher);

    [Post("/Task")] public Task<TaskDto> CreateTaskAsync(TaskDto task);
    [Delete("/Agent/{id}")] public Task DeleteAgentAsync(int id);
    [Delete("/AgentBinaries/{id}")] public Task DeleteAgentBinaryAsync(int id);
    [Delete("/CrackerBinary/{id}")] public Task DeleteCrackerBinaryAsync(int id);
    [Delete("/Hashlist/{id}")] public Task DeleteHashlistAsync(int id);

    [Delete("/RegistrationVoucher/{id}")] public Task DeleteRegistrationVoucherAsync(int id);
    [Delete("/Task/{id}")] public Task DeleteTaskAsync(int id);
    [Get("/Agent/{id}")] public Task<AgentDto> GetAgentAsync(int id);
    [Get("/AgentBinaries/{id}")] public Task<AgentBinaryDto> GetAgentBinaryAsync(int id);

    [Get("/AgentBinaries")] public Task<List<AgentBinaryDto>> GetAllAgentBinariesAsync();
    [Get("/Agent")] public Task<List<AgentDto>> GetAllAgentsAsync();

    [Get("/CrackerBinary")] public Task<List<CrackerBinaryDto>> GetAllCrackerBinariesAsync();


    [Get("/Hashlist")] public Task<List<HashlistDto>> GetAllHashlistsAsync();

    [Get("/RegistrationVoucher")] public Task<List<RegistrationVoucherDto>> GetAllRegistrationVouchersAsync();

    [Get("/Task")] public Task<List<TaskDto>> GetAllTasksAsync();
    [Get("/CrackerBinary/{id}")] public Task<CrackerBinaryDto> GetCrackerBinaryAsync(int id);
    [Get("/Hashlist/{id}")] public Task<HashlistDto> GetHashlistAsync(int id);
    [Get("/RegistrationVoucher/{id}")] public Task<RegistrationVoucherDto> GetRegistrationVoucherAsync(int id);
    [Get("/Task/{id}")] public Task<TaskDto> GetTaskAsync(int id);
    [Put("/Agent/{id}")] public Task UpdateAgentAsync(int id, AgentDto agent);

    [Put("/AgentBinaries/{id}")]
    public Task UpdateAgentBinaryAsync(int id, AgentBinaryDto agentBinary);

    [Put("/CrackerBinary/{id}")]
    public Task UpdateCrackerBinaryAsync(int id, CrackerBinaryDto crackerBinary);

    [Put("/Hashlist/{id}")] public Task UpdateHashlistAsync(int id, HashlistDto hashlist);

    [Put("/RegistrationVoucher/{id}")]
    public Task UpdateRegistrationVoucherAsync(int id, RegistrationVoucher voucher);

    [Put("/Task/{id}")] public Task UpdateTaskAsync(int id, TaskDto task);
}
