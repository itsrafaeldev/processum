using processum.DTO;
using processum.DTO.Response;

namespace processum.Services.interfaces
{
    public interface IEntityInterface
    {
        Task<IEnumerable<EntityResponse>> GetEntitiesAsync();
        Task<EntityResponse?> GetByIdAsync(Guid idPublic);
        Task CreateEntityIndividualAsync(EntityIndividualRequest request);
        Task CreateEntityCompanyAsync(EntityCompanyRequest request);
        Task UpdateEntityIndividualAsync(Guid entityId, EntityIndividualRequest request);
        Task UpdateEntityCompanyAsync(Guid entityId, EntityCompanyRequest request);
        Task DeleteEntityAsync(Guid entityId);
    }
}