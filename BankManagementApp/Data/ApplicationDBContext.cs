
using BankManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankManagementApp.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransferType> TransferTypes { get; set; }
        public DbSet<FundTransfer> FundTransfers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           // Seed Roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1", // Use a unique ID for each role
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Admin User
            var hasher = new PasswordHasher<AppUser>();
            var adminUser = new AppUser
            {
                Id = "admin-user-id", 
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@bank.com",
                NormalizedEmail = "ADMIN@BANK.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"), 
                SecurityStamp = string.Empty
            };
            builder.Entity<AppUser>().HasData(adminUser);

            
            var adminUserRole = new IdentityUserRole<string>
            {
                RoleId = "1", 
                UserId = "admin-user-id" 
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);
        }
    }
}