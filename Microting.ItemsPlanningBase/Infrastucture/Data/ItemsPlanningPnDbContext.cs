using Microsoft.EntityFrameworkCore;
using Microting.eFormApi.BasePn.Abstractions;
using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;
using Microting.ItemsPlanningBase.Infrastucture.Data.Entities;

namespace Microting.ItemsPlanningBase.Infrastucture.Data
{
    public class ItemsPlanningPnDbContext: DbContext, IPluginDbContext
    {

        public ItemsPlanningPnDbContext() { }

        public ItemsPlanningPnDbContext(DbContextOptions<ItemsPlanningPnDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemVersion> ItemVersions { get; set;}
        public DbSet<ItemLIst> ItemLists { get; set; }
        public DbSet<ItemListVersion> ItemListVersions { get; set; }
        public DbSet<ItemCase> ItemCases { get; set; }
        public DbSet<ItemCaseVersion> ItemCaseVersions { get; set; }
        
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }
        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}