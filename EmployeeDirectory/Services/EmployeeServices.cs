using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Services
{
    public class EmployeeServices : IEmployeeServices
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
            var result = (from e in db.Employees
                          select e).ToList();
            return result;
        }

        public Employee GetEmployeeByEmail(string email)
        {
            var result = (from e in db.Employees
                          where e.Email.Equals(email)
                          select e).FirstOrDefault();
            return result;
        }

        public Employee GetEmployeeById(int Id)
        {
            var result = db.Employees.Find(Id);
            return result;
        }

        public void InsertEmployee(Employee emp)
        {
            Employee employee = new Employee()
            {

            };
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = db.Employees.Find(emp.Id);

            //update data code
            employee.FirstName = emp.FirstName;
            //update data code

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void DeleteEmployee(int Id)
        {
            var employee = db.Employees.Find(Id);
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
        }

    }
}