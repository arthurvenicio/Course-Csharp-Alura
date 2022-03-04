using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ApiUsers.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> opts, IConfiguration configuration) : base(opts)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityUser<int> admin = new IdentityUser<int>()
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 0620251425
            };

            var passwordHasher = new PasswordHasher<IdentityUser<int>>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, _configuration.GetValue<string>("admincredentials:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>()
                {
                    Id = 48475,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                });
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>()
                {
                    Id = 54859,
                    Name = "regular",
                    NormalizedName = "REGULAR",
                });

            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { 
                RoleId = 48475,
                UserId = 0620251425,
            });
        }
    }
}
