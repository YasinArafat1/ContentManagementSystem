using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Class_012_Practices.Models
{
    public class Article
    {
        public Article()
        {
            this.ArticleTags = new List<ArticleTag>();
        }
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Title Required"), StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Date is  Required"),Display(Name ="Publish Date"),Column(TypeName ="date"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime PublishDate { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
    public class Tag
    {
        public Tag()
        {
            this.ArticleTags = new List<ArticleTag>();
        }
        public int TagId { get; set; }
        [Required(ErrorMessage ="Tag Name Required"),StringLength(50),Display(Name ="Tag Name")]
        public string TagName { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

    }
    public class ArticleTag
    {
        [Key,Column(Order =1)]
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        [Key,Column(Order =2)]
        [ForeignKey("Tag")]
        public int TagId { get; set; }

        //nev

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }    

    }

    public class ArticleDbContext:DbContext
    { 
        public DbSet<Article> Articles { get; set;}
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
    
    }


}