using EmployeeDirectory.Models;
using EmployeeDirectory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeDirectory.Controllers
{
    public class DefaultController : ApiController
    {
        #region Fields
        private readonly IEmployeeServices _employeeSevices;
        #endregion

        #region Ctor
        public DefaultController()
        {
            _employeeSevices = new EmployeeServices();
        }
        #endregion

        [HttpGet]
        [Route("api/GetContries")]
        public HttpResponseMessage GetContries()
        {
            try
            {
                var contrys = _employeeSevices.GetContries();

                return Request.CreateResponse(HttpStatusCode.OK, contrys.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/GetCitys")]
        public HttpResponseMessage GetCitiesByState(int StateId)
        {
            try
            {
                if (StateId == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid State Id.");

                var cities = _employeeSevices.GetCityByState(StateId);

                return Request.CreateResponse(HttpStatusCode.OK, cities.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("api/GetStates")]
        public HttpResponseMessage GetStatesByContry(int ContryId)
        {
            try
            {
                if (ContryId == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Contry Id.");

                var states = _employeeSevices.GetStatesByContry(ContryId);

                return Request.CreateResponse(HttpStatusCode.OK, states.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/AddEmployee")]
        public HttpResponseMessage Insert(Employee employee)
        {
            try
            {
                if (employee == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Data.");

                _employeeSevices.InsertEmployee(employee);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/UpdateEmployee")]
        public HttpResponseMessage Update(Employee employee)
        {
            try
            {
                if (employee == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Data.");

                _employeeSevices.UpdateEmployee(employee);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("api/DeleteEmployee")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                if (Id == 0)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Data.");

                _employeeSevices.DeleteEmployee(Id);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

    }
}
