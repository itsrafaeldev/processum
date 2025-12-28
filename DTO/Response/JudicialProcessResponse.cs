using processum.Models;

namespace processum.DTO.Response
{
    public class JudicialProcessResponse
    {
        public Guid IdPublic { get; set; }

        public string ProcessNumber { get; set; } = null!;

        public DateOnly InitialDate { get; set; }

        public string Respondent { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; }

        public SelectOptionResponse NatureAction { get; set; } = null!;

        public SelectOptionResponse JudicialAction { get; set; } = null!;

        public long User { get; set; }

        public List<EntityResponse> Entities { get; set; } = new();
    }
}