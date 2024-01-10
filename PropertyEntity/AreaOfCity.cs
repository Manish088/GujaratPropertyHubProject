using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyEntity
{
    public class AreaOfCity
    {
        [Key]
        public int AreaOfCityId { get; set; }
        public string AreaOfCityName { get; set; }

        // Navigation property for the relationship with City
        public City City { get; set; }

        // Foreign key property
        [ForeignKey("City")]
        public int CityId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }

}
