namespace Class_012_Practices.Migrations
{
    using Class_012_Practices.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Class_012_Practices.Models.ArticleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Class_012_Practices.Models.ArticleDbContext db)
        {
            Tag t1 = new Tag { TagName = "C#" };
            Tag t2 = new Tag { TagName = ".Net" };
            Tag t3 = new Tag { TagName = "MVC5" };
            Tag t4 = new Tag { TagName = "Asp.Net core" };
            Tag t5 = new Tag { TagName = "Angular" };

            db.Tags.AddRange(new Tag[] { t1, t2, t3, t4, t5 });

            Article a = new Article { Title = "Getting Started With ASP.NET Core", PublishDate = new DateTime(2021, 6, 1) };

            a.ArticleTags.Add(new ArticleTag { Tag = t3 });
            a.ArticleTags.Add(new ArticleTag { Tag = t4 });

            db.Articles.Add(a);
            db.SaveChanges(); 


        }
    }
}
