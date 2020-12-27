using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectoryUI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public DateTime Birthdate { get; set; }
        public string hobbies { get; set; }
        public string Images { get; set; }
        public decimal salary { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Zipcode { get; set; }
        public string Password { get; set; }
    }
}