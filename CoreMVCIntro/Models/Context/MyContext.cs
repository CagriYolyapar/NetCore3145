using CoreMVCIntro.DBConfiguration;
using CoreMVCIntro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCIntro.Models.Context
{

    //EntityFrameworkCore.SqlServer kütüphanesini indirmeyi de unutmayın...Options ayarları yoksa gelmeyecektir...
    public class MyContext:DbContext
    {


        //Dependency Injection yapısı Core platformunuzun arkasında otomatik olarak entegre gelir...Dolayısıyla siz bir veritabanı sınıfınızın constructor'ina parametre olarak bir Options tipinde verirseniz bu parametreye argüman olarak gönderilir...

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: "server=.,database=CoreCodeFirstDB;uid=sa;pwd=123");
        //}




        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetail>().Property(x => x.ID).UseIdentityColumn();

            //modelBuilder.Entity<OrderDetail>().Ignore(x => x.ID);

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        

        //.Net Core üzerinden migrate yapmak istediginiz takdirde add-migration <isim> ve sonrasında update-database demeniz gerekir...

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AppUserProfile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}
