using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class RepositoryContext : DbContext {

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>().HasKey(x=>x.KitapId);
            modelBuilder.Entity<Roll>().HasKey(x => x.RollId);

        }




        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Roll> Rolller { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }

    }
}
