namespace processum.DTO
{
    public class JudicialProcessRequest
    {
        public string ProcessNumber { get; set; } = null!;

        public DateOnly InitialDate { get; set; }

        public string Respondent { get; set; } = null!;

        public string? Description { get; set; }

        public int NatureActionId { get; set; }

        public int JudicialActionId { get; set; }

        public long UserId { get; set; }

        // ids das entidades relacionadas (pivot)
        public List<Guid> EntityIds { get; set; } = new();
    }
}