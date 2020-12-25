using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Services
{
    public class Employee : IEmployee
    {
        private readonly DatabaseContext db;
        public Employee()
        {
            db = new DatabaseContext();
        }

        public List<Country> GetContries()
        {
            return null;
        }

        public List<State> GetStatesByContry(int ContryId)
        {
            return null;
        }

        public List<City> GetCityByState(int StateId)
        {
            return null;
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