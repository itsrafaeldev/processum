using processum.DTO;
using processum.DTO.Response;

namespace processum.Services.interfaces
{
    public interface IEntityService
    {
        Task<IEnumerable<EntityResponse>> GetEntitiesAsync();
        Task<EntityResponse?> GetByIdAsync(Guid idPublic);

        Task CreateEntityIndividualAsync(EntityIndividualRequest request);
        Task CreateEntityCompanyAsync(EntityCompanyRequest request);

        Task<bool> UpdateEntityIndividualAsync(Guid entityId, EntityIndividualRequest request);
        Task<bool> UpdateEntityCompanyAsync(Guid entityId, EntityCompanyRequest request);

        Task<bool> DeleteEntityAsync(Guid entityId);
    }
}