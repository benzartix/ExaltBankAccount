using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Transaction : BaseEntity
    {
        [MaxLength(50)]
        public string Operation { get; set; }
        public Account Account { get; set; }
    }
}
