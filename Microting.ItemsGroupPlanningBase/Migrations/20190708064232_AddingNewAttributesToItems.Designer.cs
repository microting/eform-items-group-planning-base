﻿// <auto-generated />

namespace Microting.ItemsGroupPlanningBase.Migrations
{
    using System;
    using Infrastructure;
    using Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    [DbContext(typeof(ItemsGroupPlanningPnDbContext))]
    [Migration("20190708064232_AddingNewAttributesToItems")]
    partial class AddingNewAttributesToItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            if (DbConfig.IsMySQL)
            {
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<string>("BuildYear");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<int>("ItemListId");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<string>("Sku");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ItemListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("ItemId");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemCases");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemCaseVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("ItemCaseId");

                    b.Property<int>("ItemId");

                    b.Property<int>("MicrotingSdkCaseId");

                    b.Property<int>("MicrotingSdkSiteId");

                    b.Property<int>("MicrotingSdkeFormId");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemCaseVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("DayOfMonth");

                    b.Property<int?>("DayOfWeek");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<DateTime?>("LastExecutedTime");

                    b.Property<string>("Name");

                    b.Property<int>("RelatedEFormId");

                    b.Property<string>("RelatedEFormName");

                    b.Property<int>("RepeatEvery");

                    b.Property<int>("RepeatType");

                    b.Property<DateTime?>("RepeatUntil");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemLists");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemListVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("DayOfMonth");

                    b.Property<int?>("DayOfWeek");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<int>("ItemListId");

                    b.Property<DateTime?>("LastExecutedTime");

                    b.Property<string>("Name");

                    b.Property<int>("RelatedEFormId");

                    b.Property<string>("RelatedEFormName");

                    b.Property<int>("RepeatEvery");

                    b.Property<int>("RepeatType");

                    b.Property<DateTime?>("RepeatUntil");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemListVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<string>("BuildYear");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<int>("ItemId");

                    b.Property<int>("ItemListId");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("LocationCode");

                    b.Property<string>("Name");

                    b.Property<string>("Sku");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ItemVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIDGenStrategy, autoIDGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.Item", b =>
                {
                    b.HasOne("Microting.ItemsPlanningBase.Infrastructure.Data.Entities.ItemList")
                        .WithMany("Items")
                        .HasForeignKey("ItemListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
