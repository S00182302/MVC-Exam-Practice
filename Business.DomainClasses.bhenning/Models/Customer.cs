using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.bhenning.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
    }
}
