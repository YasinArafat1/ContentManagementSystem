using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Class_012_Practices.Models.ViewModels
{
    public class ArticleViewModel
    {
       
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Title Required"), StringLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Date is  Required"), Display(Name = "Publish Date"), Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public string  Tags  { get; set; }



    }
}