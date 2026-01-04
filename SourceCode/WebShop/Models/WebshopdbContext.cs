using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models;

public partial class WebshopdbContext : DbContext
{
    public WebshopdbContext()
    {
    }

    public WebshopdbContext(DbContextOptions<WebshopdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<SalesOrder> SalesOrders { get; set; }

    public virtual DbSet<SiteStatistic> SiteStatistics { get; set; }

    public virtual DbSet<StaticPage> StaticPages { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=WEBSHOPDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PK_FaqId");

            entity.ToTable("FAQ");

            entity.Property(e => e.Answer).HasColumnType("ntext");
            entity.Property(e => e.Question).HasMaxLength(255);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.OrderProductId).HasName("PK_OrderDetail");

            entity.ToTable("OrderProduct");

            entity.Property(e => e.Quantity).HasDefaultValue((byte)1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderProduct_SalesOrder");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BigImage).HasColumnType("image");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProductNumber).HasMaxLength(50);
            entity.Property(e => e.ShortDesc).HasMaxLength(255);
            entity.Property(e => e.SmallImage).HasColumnType("image");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_Category");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<SalesOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_OrderMaster");

            entity.ToTable("SalesOrder");

            entity.Property(e => e.AddressLine1).HasMaxLength(200);
            entity.Property(e => e.BillingAddress).HasMaxLength(150);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Customer).HasMaxLength(30);
            entity.Property(e => e.DeliveryAddress).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.OrderNumber).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        modelBuilder.Entity<SiteStatistic>(entity =>
        {
            entity.HasKey(e => e.StatisticId);

            entity.ToTable("SiteStatistic");

            entity.Property(e => e.StatisticId).ValueGeneratedNever();
        });

        modelBuilder.Entity<StaticPage>(entity =>
        {
            entity.HasKey(e => e.PageId);

            entity.ToTable("StaticPage");

            entity.Property(e => e.PageId)
                .ValueGeneratedNever()
                .HasColumnName("PageID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LanguageId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("LanguageID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PageContent).HasColumnType("ntext");
            entity.Property(e => e.PageTitle).HasMaxLength(255);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("UserAccount");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.UserGroup).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.UserGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAccount_UserGroup");
        });

        modelBuilder.Entity<UserGroup>(entity =>
        {
            entity.ToTable("UserGroup");

            entity.Property(e => e.UserGroupId).HasColumnName("UserGroupID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
