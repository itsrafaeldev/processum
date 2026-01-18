using processum.DTO;
using processum.DTO.Response;

namespace processum.Services.interfaces
{
    public interface IJudicialProcessService
    {
        Task<IEnumerable<JudicialProcessResponse>> GetAllAsync();
        Task<JudicialProcessResponse?> GetByIdAsync(Guid idPublic);
        Task CreateAsync(JudicialProcessRequest request);
        Task<bool> DeleteAsync(Guid idPublic);
    }
}
