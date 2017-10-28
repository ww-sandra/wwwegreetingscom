using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace halloween.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
