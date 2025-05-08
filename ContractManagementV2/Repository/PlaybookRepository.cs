using ContractManagementV2.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace ContractManagementV2.Repository
{
    public class PlaybookRepository : IPlaybookRepository
    {
        private readonly ContractDbContext context;

        public PlaybookRepository(ContractDbContext context)
        {
            this.context = context;
        }
        public void AddPlaybook(Playbook playbook)
        {
            context.Playbooks.Add(playbook);
            context.SaveChanges();
        }

        public void DeletePlaybook(Playbook playbook)
        {
            var existingPlaybook = context.Playbooks
                //.AsNoTracking()
                    .Include(p => p.PlaybookItems) // Include related PlaybookItems
                    .FirstOrDefault(p => p.Id == playbook.Id);

            if (existingPlaybook != null)
            {
                context.PlaybookItems.RemoveRange(existingPlaybook.PlaybookItems); // Delete related items
                context.Playbooks.Remove(existingPlaybook);
                context.SaveChanges();
            }
        }

        public IEnumerable<Playbook> GetEntityByFirmId(string firmId)
        {
            return context.Playbooks
            .Include(p => p.PlaybookItems) // Ensure PlaybookItems are included
            .AsNoTracking()
            .Where(x => x.FirmId == firmId)
            .ToList();
        }

        public IEnumerable<Playbook> GetEntityByUserId(string userId)
        {
            return context.Playbooks
            .Include(p => p.PlaybookItems) // Ensure PlaybookItems are included
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToList();
        }

        public Playbook GetEntityById(int id)
        {
            return context.Playbooks
            .Include(p => p.PlaybookItems) // Ensure PlaybookItems are included
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
        }

        public void AddPlaybookItem(PlaybookItem playbookItem)
        {
            context.PlaybookItems.Add(playbookItem);
            context.SaveChanges();
        }

        public void UpdatePlaybook(Playbook playbook)
        {
            var existingPlaybook = context.Playbooks
            .Include(p => p.PlaybookItems) // Load existing playbook and items
            .FirstOrDefault(p => p.Id == playbook.Id);

            if (existingPlaybook != null)
            {
                context.Entry(existingPlaybook).CurrentValues.SetValues(playbook); // Update main fields

                // Handle PlaybookItems Updates
                //context.PlaybookItems.RemoveRange(existingPlaybook.PlaybookItems); // Remove old items
                //context.PlaybookItems.AddRange(playbook.PlaybookItems); // Add new items

                context.SaveChanges();
            }
        }

        // 🔹 Get Playbook Items by Playbook ID
        public IEnumerable<PlaybookItem> GetPlaybookItemsByPlaybookId(int playbookId)
        {
            return context.PlaybookItems
                .AsNoTracking()
                .Where(pi => pi.PlaybookId == playbookId)
                .ToList();
        }
        // 🔹 Get Playbook Items by PlaybookItem ID
        public PlaybookItem? GetPlaybookItemsByPlaybookItemId(int playbookItemId)
        {
            return context.PlaybookItems
                .AsNoTracking()
                .Where(pi => pi.Id == playbookItemId)
                .FirstOrDefault();
        }

        public void UpdatePlaybookItem(PlaybookItem updatedItem)
        {
            var existingItem = context.PlaybookItems.FirstOrDefault(pi => pi.Id == updatedItem.Id);
            if (existingItem != null)
            {
                // Ensure PlaybookId is NOT modified
                updatedItem.PlaybookId = existingItem.PlaybookId;

                context.Entry(existingItem).CurrentValues.SetValues(updatedItem);
                context.SaveChanges();
            }
        }



        // 🔴 Delete PlaybookItem
        public void DeletePlaybookItem(PlaybookItem playbookItem)
        {
            context.PlaybookItems.Remove(playbookItem);
            context.SaveChanges();
        }

    }
}
