namespace processum.Models;

public partial class LegalFeeEntity
{

    public long LegalFeeId { get; set; }
    public LegalFee LegalFee { get; set; } = null!;

    public long EntityId { get; set; }
    public Entity Entity { get; set; } = null!;

    public LegalFeeEntity()
    {
        
    }
}
