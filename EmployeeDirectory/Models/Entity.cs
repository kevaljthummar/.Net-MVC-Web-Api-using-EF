using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<State> State { get; set; }
    }

    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public List<City> City { get; set; }
        //Adding Foreign Key constraints for country  
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        //Adding Foreign Key Constraints for State  
        public int StateId { get; set; }
        public State State { get; set; }
    }

    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required,
         StringLength(50),
         DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Required,StringLength(1)]
        public string Gender { get; set; }
                
        public bool MaritalStatus { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [StringLength(100)]
        public string hobbies { get; set; }
        public string Images { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999.99)]
        public decimal salary { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }

        [StringLength(6)]
        public string Zipcode { get; set; }

        [Required,StringLength(50)]
        public string Password { get; set; }
    }
}