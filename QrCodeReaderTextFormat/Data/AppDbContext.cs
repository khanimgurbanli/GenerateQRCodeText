using Microsoft.EntityFrameworkCore;
using QrCodeReaderTextFormat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeReaderTextFormat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7VK5UN3\\SQLEXPRESS; Database=QrCodeText; Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<VCard> VCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
