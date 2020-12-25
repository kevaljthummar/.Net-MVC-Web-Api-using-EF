using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectory.Services
{
    public interface IEmployee
    {
        List<Country> GetContries();
        List<State> GetStatesByContry(int ContryId);
        List<City> GetCityByState(int StateId);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByEmail(string email);
        Employee GetEmployeeById(int Id);
        void InsertEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int Id);
    }
}