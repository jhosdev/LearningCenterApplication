using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LearningCenter.Infrastructure.Models;
namespace LearningCenter.Infrastructure.Context;

public class LearningCenterContext : DbContext
{
    public LearningCenterContext()
    {
        
    }
    
    public LearningCenterContext(DbContextOptions<LearningCenterContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=root;Database=tramigodb;", serverVersion);
        }
    }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Username)
                .HasColumnName("username")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.LastName1)
                .HasColumnName("last_name_1")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.LastName2)
                .HasColumnName("last_name_2")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(20)");

            entity.Property(e => e.Verified)
                .HasColumnName("verified")
                .HasColumnType("bit");

            entity.Property(e => e.PaymentMethod)
                .HasColumnName("payment_method")
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Company)
                .HasColumnName("company")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.Dni)
                .HasColumnName("dni")
                .HasColumnType("varchar(20)");

            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            entity.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .IsRequired();
        });
        
    
    }
    */
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Username).IsRequired().HasMaxLength(60);
        
        builder.Entity<Procedure>().ToTable("Procedures");
        builder.Entity<Procedure>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Procedure>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

    }
}