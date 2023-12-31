using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyEntity
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public Country country { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
