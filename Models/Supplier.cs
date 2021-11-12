using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntitytoDatabse.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Display(Name="Supplier Name")]
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}