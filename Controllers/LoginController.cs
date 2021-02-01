using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;
using AirlineRWebApi.VM;

namespace AirlineRWebApi.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        AirlineREntities2 db = new AirlineREntities2();
        [Route("Insert")]
        [HttpPost]
        public object Insert(Customer Cu)
        {
            try
            {
                Customer c = new Customer();
                if(c.Cid == 0)
                {
                    c.Cname = Cu.Cname;
                    c.Address = Cu.Address;
                    c.Gender = Cu.Gender;
                    c.DOB = Cu.DOB;
                    c.Phone = Cu.Phone;
                    c.Email = Cu.Email;
                    c.Password = Cu.Password;
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record succesfully saved" };
                }
            }
            catch(Exception)
            {
                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data" };

        }

        [Route("Login")]
        [HttpPost]
        public Response Login (Login login)
        {
            var log = db.Customers.Where(x => x.Email.Equals(login.Email) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invaid User" };
            }
            else
                return new Response { Status = "Success", Message = "Login succesfull" };

           

        }
       
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }
}