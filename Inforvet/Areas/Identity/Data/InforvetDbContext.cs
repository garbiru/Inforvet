using Inforvet.Areas.Identity.Data;
using Inforvet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inforvet.Areas.Identity.Data;

public class InforvetDbContext : IdentityDbContext<InforvetUser>
{
    public InforvetDbContext(DbContextOptions<InforvetDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }

    public DbSet<Inforvet.Models.Utente> Utente { get; set; }

    public DbSet<Inforvet.Models.Cliente> Cliente { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<InforvetUser>
{
    public void Configure(EntityTypeBuilder<InforvetUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.NIF).HasMaxLength(9);
    }
}