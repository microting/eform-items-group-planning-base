using Microsoft.EntityFrameworkCore;
using Microting.ItemsPlanningBase.Infrastucture.Data.Entities;

namespace Microting.ItemsPlanningBase.Infrastucture.Data
{
    public class ItemsPlanningPnDbContext: DbContext
    {

        public ItemsPlanningPnDbContext() { }

        public ItemsPlanningPnDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemVersion> ItemVersions { get; set;}
        public DbSet<ItemLIst> ItemLists { get; set; }
        public DbSet<ItemListVersion> ItemListVersions { get; set; }
        public DbSet<ItemsPlanningPnSetting> ItemsPlanningPnSettings { get; set; }
        public DbSet<ItemsPlanningPnSettingVersion> ItemsPlanningPnSettingVersions { get; set; }
        public DbSet<ItemCase> ItemCases { get; set; }
        public DbSet<ItemCaseVersion> ItemCaseVersions { get; set; }
        
        public virtual Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade ContextDatabase
        {
            get => base.Database;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}