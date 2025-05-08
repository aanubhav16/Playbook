using ContractManagementV2.Model;
using Microsoft.AspNetCore.JsonPatch;

namespace ContractManagementV2.Repository
{
    public interface IPlaybookRepository
    {
        public void AddPlaybook(Playbook playbook);
        public void UpdatePlaybook(Playbook playbook);
        public void DeletePlaybook(Playbook playbook);
        public Playbook GetEntityById(int id);
        public IEnumerable<Playbook> GetEntityByFirmId(string firmId);
        public IEnumerable<Playbook> GetEntityByUserId(string userId);
        public void AddPlaybookItem(PlaybookItem playbookItem);

        public IEnumerable<PlaybookItem> GetPlaybookItemsByPlaybookId(int playbookId);
        public PlaybookItem? GetPlaybookItemsByPlaybookItemId(int playbookItemId);

        public void UpdatePlaybookItem(PlaybookItem updatedItem);
        public void DeletePlaybookItem(PlaybookItem playbookItem);
    }
}
