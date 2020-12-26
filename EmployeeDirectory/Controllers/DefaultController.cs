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
        private readonly IEmployee _employee;
        #endregion

        #region Ctor
        public DefaultController()
        {
            _employee = new Employee();
        }
        #endregion

        [HttpGet]
        [Route("api/GetContries")]
        public HttpResponseMessage GetContries()
        {
            try
            {
                var contrys = _employee.GetContries();

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
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,"Invalid State Id.");

                var cities = _employee.GetCityByState(StateId);

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
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Contry Id.");

                var states = _employee.GetStatesByContry(ContryId);

                return Request.CreateResponse(HttpStatusCode.OK, states.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

    }
}
