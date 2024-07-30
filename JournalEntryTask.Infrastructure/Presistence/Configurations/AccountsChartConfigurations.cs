using JournalEntryTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JournalEntryTask.Infrastructure.Presistence.Configurations
{
    public class AccountsChartConfigurations : IEntityTypeConfiguration<AccountsChart>
    {
        public void Configure(EntityTypeBuilder<AccountsChart> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Accounts__3214EC2748817F42");

            builder.ToTable("AccountsChart");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            builder.Property(e => e.AllowEntry).HasColumnName("Allow_Entry");
            builder.Property(e => e.BranchId).HasColumnName("Branch_ID");
            builder.Property(e => e.ChartLevelDepth).HasColumnName("Chart_Level_Depth");
            builder.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            builder.Property(e => e.FkCostCenterTypeId).HasColumnName("FK_Cost_Center_Type_ID");
            builder.Property(e => e.FkTransactionTypeId).HasColumnName("FK_Transaction_Type_ID");
            builder.Property(e => e.FkWorkFieldsId).HasColumnName("FK_Work_Fields_ID");
            builder.Property(e => e.IsActive).HasColumnName("Is_Active");
            builder.Property(e => e.NameAr)
                .HasMaxLength(150)
                .HasColumnName("NameAR");
            builder.Property(e => e.NameEn)
                .HasMaxLength(150)
                .HasColumnName("NameEN");
            builder.Property(e => e.NoOfChilds).HasColumnName("noOfChilds");
            builder.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.OrgId).HasColumnName("Org_ID");
            builder.Property(e => e.ParentId).HasColumnName("Parent_ID");
            builder.Property(e => e.ParentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Parent_Number");
            builder.Property(e => e.Status).HasDefaultValueSql("((1))");
            builder.Property(e => e.UserId).HasColumnName("User_ID");
        }
        
    }
}
