using System;
using System.Collections.Generic;

namespace processum.Models;

public partial class Entity
{
    public long Id { get; set; }

    public string EntityType { get; set; } = null!;

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid IdPublic { get; set; }

    // public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    // public virtual ICollection<EntityCompany> EntitiesCompanies { get; set; } = new List<EntityCompany>();

    // public virtual ICollection<EntityIndividual> EntitiesIndividuals { get; set; } = new List<EntityIndividual>();
    public virtual EntityIndividual? EntityIndividual { get; set; }
    public virtual EntityCompany? EntityCompany { get; set; }

    // public virtual ICollection<EntitiesRolesMap> EntitiesRolesMaps { get; set; } = new List<EntitiesRolesMap>();

    public virtual ICollection<LegalFeesInstallment> LegalFeesInstallments { get; set; } = new List<LegalFeesInstallment>();

    public ICollection<JudicialProcessEntity> JudicialProcessEntities { get; set; } = new List<JudicialProcessEntity>();

    public ICollection<LegalFeeEntity> LegalFeeEntities { get; set; } = new List<LegalFeeEntity>();
    
    public Entity()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    }
