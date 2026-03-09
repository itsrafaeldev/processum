using OctaPro.DTO;
using OctaPro.DTO.Response;

namespace OctaPro.Services.interfaces
{
    public interface IJudicialProcessService
    {
        Task<IEnumerable<JudicialProcessResponse>> GetAllAsync();
        Task<JudicialProcessResponse?> GetByIdAsync(Guid idPublic);
        Task CreateAsync(JudicialProcessRequest request, Guid userLoggedUUID);
        Task<bool> DeleteAsync(Guid idPublic);

        Task<IEnumerable<SelectOptionResponse>> GetAllNatureAsync();
        Task<IEnumerable<SelectOptionResponse>> GetActionsAsync(int natureId);



    }
}
