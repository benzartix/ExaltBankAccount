using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Fistname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
