using Class_012_Practices.Models;
using Class_012_Practices.Models.InputModel;
using Class_012_Practices.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Class_012_Practices.Controllers
{
    public class HomeController : Controller
    {
        ArticleDbContext db = new ArticleDbContext();
        public ActionResult Index()
        {
            var viewModelData = db.Articles.AsEnumerable().Select(a => new ArticleViewModel
            {
                ArticleId = a.ArticleId,
                Title = a.Title,
                PublishDate = a.PublishDate,
                Tags = string.Join(", ", a.ArticleTags.Select(t => t.Tag.TagName).ToArray())


            });


            return View(viewModelData);
        }

        public ActionResult Create()
        {
            ViewBag.checkBoxData = db.Tags.ToList();

            return View();
        }

        [HttpPost]

        public ActionResult Create(Article a, int[] tagId )
        {
            if (ModelState.IsValid)
            {
                foreach (var id in tagId)
                {
                    a.ArticleTags.Add(new ArticleTag { TagId = id });
                }
                db.Articles.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.checkBoxData = db.Tags.ToList();
            return View(a);
        }


        public ActionResult Edit(int id)
        {
            var article = db.Articles.First(x => x.ArticleId == id);

            var checkBoxItems = db.Tags.Select(t => new CheckBoxModel
            {
                TagId = t.TagId,
                TagName = t.TagName,
                Selected = false
            }).ToList();

            foreach (var a in article.ArticleTags)
            {
                checkBoxItems.First(x => x.TagId == a.TagId).Selected = true;
            }
            ViewBag.checkBoxData = checkBoxItems;
            return View(article);
        }

       
        [HttpPost]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var article = db.Articles.FirstOrDefault(x => x.ArticleId == model.ArticleId);

                if (article != null)
                {
                    // Update article properties

                    

                    article.Title = model.Title;
                    article.PublishDate = model.PublishDate;


                    var checkBoxItems = db.Tags.Select(t => new CheckBoxModel
                    {
                        TagId = t.TagId,
                        TagName = t.TagName,
                        Selected = true
                    }).ToList();
                    ViewBag.checkBoxData = checkBoxItems;
                }
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
            
          
        }


        public ActionResult Delete(int id)
        {
            var article = db.Articles.First(x => x.ArticleId == id);

            var checkBoxItems = db.Tags.Select(t => new CheckBoxModel
            {
                TagId = t.TagId,
                TagName = t.TagName,
                Selected = false
            }).ToList();
            //check box e sir list hisebe patayce tai nice foreach dice itarate korar jonno
            foreach (var a in article.ArticleTags)
            {
                checkBoxItems.First(x => x.TagId == a.TagId).Selected = true;
            }
            ViewBag.checkBoxData = checkBoxItems;
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            var article = db.Articles.First(x => x.ArticleId == id);

            if (article == null)
            {
                return HttpNotFound();
            }

            db.Entry(article).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
























        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}