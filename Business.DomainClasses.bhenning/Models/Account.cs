using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.bhenning.Models
{
    class Account
    {
        [Key]
        public int ID { get; set; }
        public String AccountName { get; set; }
        public DateTime InceptionDate { get; set; }
        [ForeignKey("associatedCustomer")]
        public int CustomerID { get; set; }
        [Column(TypeName = "Money")]
        public decimal CurrentBalance { get; set; }
        public int AccountTypeID { get; set; }

        public virtual Customer associatedCustomer { get; set; }
    }
}
