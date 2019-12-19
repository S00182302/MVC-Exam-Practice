using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.bhenning.Models
{
    enum TransactionType { Lodgement = 0, WithDrawal = 1}
    class Transactions
    {
        public int ID { get; set; }
        public TransactionType TransactionType { get; set; }
        [Column(TypeName = "Money")]
        public Decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        [ForeignKey("associatedAccountID")]
        public int AccountID { get; set; }

        // Connections - Relationships
        public virtual Customer associatedAccountID { get; set; }
    }
}
