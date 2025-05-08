using System.ComponentModel.DataAnnotations;

namespace ContractManagementV2.Model
{
    public class Playbook
    {
        [Key]
        public int Id { get; set; }
        public string PlaybookName { get; set; } = null!;
        public string PlaybookDescription { get; set; }
        public string FirmId { get; set;} = null!;
        public string UserId { get; set;} = null!;
        public List<PlaybookItem> PlaybookItems { get; set; } = new List<PlaybookItem>();
    }
}
