using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopBook187.Models;
using Microsoft.Extensions.Configuration;
using ShopBook187.API.Models;

namespace ShopBook187.Data
{
    public class BooksAPIDbContext : DbContext
    {
        private readonly string _connectionString;

        public BooksAPIDbContext(DbContextOptions<BooksAPIDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _connectionString = configuration.GetConnectionString("BooksAPIDbConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<BookDTO> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chỉ định kiểu cột SQL Server cho thuộc tính Price
            modelBuilder.Entity<BookDTO>()
                .Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            // Cấu hình thực thể Book
            modelBuilder.Entity<BookDTO>().ToTable("Books");

            modelBuilder.Entity<BookDTO>().HasKey(b => b.Id);

            modelBuilder.Entity<BookDTO>()
                .Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<BookDTO>()
                .Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(50);

            // Không có khóa chính cho thực thể IdentityUserLogin<string>
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        }
    }
}
