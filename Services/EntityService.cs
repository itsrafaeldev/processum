using Microsoft.EntityFrameworkCore;
using processum.Data;
using processum.DTO;
using processum.DTO.Response;
using processum.Models;
using processum.Services.interfaces;

namespace processum.Services
{
    public class EntityService : IEntityService
    {
        private readonly AppDbContext _context;

        public EntityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EntityResponse>> GetEntitiesAsync()
        {
            return await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .Select(e => new EntityResponse
                {
                    IdPublic = e.IdPublic,
                    EntityType = e.EntityType,

                    // PF
                    Name = e.EntityIndividual.Name,
                    CPF = e.EntityIndividual.Cpf,
                    RG = e.EntityIndividual.Rg,
                    Email = e.EntityIndividual.Email,
                    Mobile = e.EntityIndividual.Mobile,
                    Phone = e.EntityIndividual.Phone,

                    // PJ
                    CorporateName = e.EntityCompany.CorporateName,
                    CNPJ = e.EntityCompany.Cnpj,
                    CorporateEmail = e.EntityCompany.CorporateEmail,
                    CorporateMobile = e.EntityCompany.CorporateMobile,
                    CorporatePhone = e.EntityCompany.CorporatePhone
                })
                .ToListAsync();
        }

        public async Task<EntityResponse?> GetByIdAsync(Guid idPublic)
        {
            return await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .Where(e => e.IdPublic == idPublic)
                .Select(e => new EntityResponse
                {
                    IdPublic = e.IdPublic,
                    EntityType = e.EntityType,

                    // PF
                    Name = e.EntityIndividual.Name,
                    CPF = e.EntityIndividual.Cpf,
                    RG = e.EntityIndividual.Rg,
                    Email = e.EntityIndividual.Email,
                    Mobile = e.EntityIndividual.Mobile,
                    Phone = e.EntityIndividual.Phone,

                    // PJ
                    CorporateName = e.EntityCompany.CorporateName,
                    CNPJ = e.EntityCompany.Cnpj,
                    CorporateEmail = e.EntityCompany.CorporateEmail,
                    CorporateMobile = e.EntityCompany.CorporateMobile,
                    CorporatePhone = e.EntityCompany.CorporatePhone
                })
                .FirstOrDefaultAsync();
        }

        public async Task CreateEntityIndividualAsync(EntityIndividualRequest request)
        {
            var entity = new Entity
            {
                IdPublic = Guid.NewGuid(),
                EntityType = "PF",
                StatusId = 1
            };

            var entityIndividual = new EntityIndividual
            {
                Entity = entity,
                Name = request.Name,
                Cpf = request.Cpf,
                Rg = request.Rg,
                Email = request.Email,
                Mobile = request.Mobile,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                Address = request.Address
            };

            _context.EntitiesIndividuals.Add(entityIndividual);
            await _context.SaveChangesAsync();
        }

        public async Task CreateEntityCompanyAsync(EntityCompanyRequest request)
        {
            var entity = new Entity
            {
                IdPublic = Guid.NewGuid(),
                EntityType = "PJ",
                StatusId = 1
            };

            var entityCompany = new EntityCompany
            {
                Entity = entity,
                Cnpj = request.Cnpj,
                CorporateName = request.CorporateName,
                TradeName = request.TradeName,
                CorporateEmail = request.CorporateEmail,
                CorporateMobile = request.CorporateMobile,
                CorporatePhone = request.CorporatePhone
            };

            _context.EntitiesCompanies.Add(entityCompany);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEntityIndividualAsync(Guid entityId, EntityIndividualRequest request)
        {
            var entityIndividual = await _context.EntitiesIndividuals
                .Include(e => e.Entity)
                .FirstOrDefaultAsync(e => e.Entity.IdPublic == entityId);

            if (entityIndividual == null)
                return false;

            entityIndividual.Name = request.Name;
            entityIndividual.Cpf = request.Cpf;
            entityIndividual.Rg = request.Rg;
            entityIndividual.Email = request.Email;
            entityIndividual.Mobile = request.Mobile;
            entityIndividual.Phone = request.Phone;
            entityIndividual.BirthDate = request.BirthDate;
            entityIndividual.Address = request.Address;

            entityIndividual.Entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateEntityCompanyAsync(Guid entityId, EntityCompanyRequest request)
        {
            var entityCompany = await _context.EntitiesCompanies
                .Include(e => e.Entity)
                .FirstOrDefaultAsync(e => e.Entity.IdPublic == entityId);

            if (entityCompany == null || entityCompany.Entity.EntityType != "PJ")
                return false;

            entityCompany.Cnpj = request.Cnpj;
            entityCompany.CorporateName = request.CorporateName;
            entityCompany.TradeName = request.TradeName;
            entityCompany.CorporateEmail = request.CorporateEmail;
            entityCompany.CorporateMobile = request.CorporateMobile;
            entityCompany.CorporatePhone = request.CorporatePhone;

            entityCompany.Entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEntityAsync(Guid entityId)
        {
            var entity = await _context.Entities
                .Include(e => e.EntityIndividual)
                .Include(e => e.EntityCompany)
                .FirstOrDefaultAsync(e => e.IdPublic == entityId);

            if (entity == null)
                return false;

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
