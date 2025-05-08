using ContractManagementV2.Model;
using Microsoft.EntityFrameworkCore;

namespace ContractManagementV2.Repository
{
    public class ContractDbContext:DbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playbook>().Property(x => x.FirmId).IsRequired();
            modelBuilder.Entity<Playbook>().HasKey(x=>x.Id);
            modelBuilder.Entity<Playbook>().Property(x => x.PlaybookName).HasColumnName("NamePlaybook");
        }

        public DbSet<Playbook> Playbooks { get; set; }
        public DbSet<PlaybookItem> PlaybookItems { get; set; }
    }
}
