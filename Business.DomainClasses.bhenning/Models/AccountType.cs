using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.bhenning.Models
{
    public class AccountType
    {
        [Key]
        public int ID { get; set; }
        public String TypeName { get; set; }
        public String Conditions { get; set; }
    }
}
