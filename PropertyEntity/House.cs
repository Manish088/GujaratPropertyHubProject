using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyEntity
{
    public class House
    {
       
            [Key]
            public int HouseId { get; set; }
            public string HouseName { get; set; }
            public string Description { get; set; }
            public float Price { get; set; }
            public string Address { get; set; }


            // Navigation properties
            public Category Category { get; set; }
            [ForeignKey("CategoryId")]
            public int CategoryId { get; set; }

            public SubCategory SubCategory { get; set; }
            [ForeignKey("SubCategoryId")]
            public int SubCategoryId { get; set; }


            public User User { get; set; }
            [ForeignKey("UserId")]
            public int UserId { get; set; }

            public Country Country { get; set; }
            [ForeignKey("CountryId")]
            public int CountryId { get; set; }

            public State State { get; set; }
            [ForeignKey("StateId")]
            public int StateId { get; set; }

            public City City { get; set; }
            [ForeignKey("CityId")]
            public int CityId { get; set; }

            public AreaOfCity AreaOfCity { get; set; }
            [ForeignKey("AreaOfCityId")]
            public int AreaOfCityId { get; set; }

            public bool IsActive { get; set; } = true;
            public bool Blocked { get; set; } = false;
            public string CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public string ModifyBy { get; set; }
            public DateTime ModifyDate { get; set; }
        }
}
