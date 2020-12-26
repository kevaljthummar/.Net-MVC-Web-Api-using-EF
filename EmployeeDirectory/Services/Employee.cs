using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Services
{
    public class Employee : IEmployee
    {
        private DatabaseContext db = new DatabaseContext();
       
        public List<Country> GetContries()
        {
            var result = (from contry in db.Countries
                         select contry).ToList();
            return result;
        }

        public List<State> GetStatesByContry(int ContryId)
        {
            var result = (from state in db.States
                          where state.CountryId.Equals(ContryId)
                          select state).ToList();

            return result;
        }

        public List<City> GetCityByState(int StateId)
        {
            var result = (from city in db.Cities
                          where city.StateId.Equals(StateId)
                          select city).ToList();

            return result;
        }

        public List<Employee> GetAllEmployees()
        {
            return null;
        }

        public Employee GetEmployeeByEmail(string email)
        {
            return null;
        }

        public Employee GetEmployeeById(int Id)
        {
            return null;
        }

        public void InsertEmployee(Employee emp)
        {

        }

        public void UpdateEmployee(Employee emp)
        {

        }

        public void DeleteEmployee(int Id)
        {

        }

    }
}