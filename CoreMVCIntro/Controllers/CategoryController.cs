using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCIntro.Models.Context;
using CoreMVCIntro.Models.Entities;
using CoreMVCIntro.VMClasses;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCIntro.Controllers
{
    public class CategoryController : Controller
    {


        //SOLID 

        //Dependency Inversion Prensibini uygulamak icin Dependency Injection tasarım paternini kullanırız...Bu patern istedigimiz şekilde istedigimiz sorumlulugun hemen o an icin enjekte edilmesini sağlayan bir tasarım paternidir... Dependency Injection en rahat Interface'ler ile kullanılır... (Böylece istedigimiz an sorumluluğu degiştirebiliriz)...İstisnai olarak DbContext yapısı SingletonPattern calıstıgından dolayı normal şartlar altında Interface üzerinden kullanılmadan DI'a burada enjekte edilmiştir...
        MyContext _db;
        public CategoryController(MyContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _db.Categories.ToList()
            };
            return View(cvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
