using DownloadApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DownloadApp.Areas.Identity.Data;

public class DownloadAppContext : IdentityDbContext<UserIdentity>
{
    public DownloadAppContext(DbContextOptions<DownloadAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserValidation());
    }
}

internal class UserValidation : IEntityTypeConfiguration<UserIdentity>
{
    public void Configure(EntityTypeBuilder<UserIdentity> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Surname).HasMaxLength(50);
    }
}