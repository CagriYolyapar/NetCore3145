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


    }
}
