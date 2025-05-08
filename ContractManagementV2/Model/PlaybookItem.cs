using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContractManagementV2.Model
{
    public class PlaybookItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Playbook")]
        public int PlaybookId { get; set; }
        public string ClauseName { get; set; } = null!;
        public string ClauseValue { get; set; } = null!;
        [JsonIgnore]
        public Playbook? Playbook { get; set; }

    }
}
