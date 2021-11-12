using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntitytoDatabse.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product Name is Required")]
        [StringLength(50)]
        public string Name { get; set; }

        //Foreign Key
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
        //Load Products with their categories
        public Category Category { get; set; }

        //[StringLength(50)]
        //public string Category { get; set; }
        public decimal Price { get; set; }
        
        [StringLength(50)]
        public string Description { get; set; }

    }
}