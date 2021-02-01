using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;

namespace AirlineRWebApi.Controllers
{
    public class FlightController : ApiController
    {
        AirlineREntities2 db = new AirlineREntities2();
        public FlightController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>
        public IEnumerable<Flight> Get()
        {
            return db.Flights.ToList();
        }

        // GET api/<controller>/5
        public Flight Get(string id)
        {
            return db.Flights.Find(id);
        }
        [HttpGet]
        public IEnumerable<Flight> Get([FromUri] string fr, [FromUri] string to)
        {
            var selectedUser = db.Flights.Where(i => i.FromPlace == fr && i.ToPlace == to);
            return selectedUser;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Flight fl)
        {
            try
            {
                db.Flights.Add(fl);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(string id, Flight fl)
        {
            try
            {
                if (id == fl.FlightNo)
                {
                    db.Entry(fl).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);

                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                Flight f = db.Flights.Find(id);
                if (f != null)
                {
                    db.Flights.Remove(f);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);

                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

    }
}