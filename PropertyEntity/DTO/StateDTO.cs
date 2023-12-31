using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyEntity.DTO
{
    public class StateDTO
    {
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
