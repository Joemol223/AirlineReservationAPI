using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;

namespace AirlineRWebApi.Controllers
{
    public class BookingController : ApiController
    {
     
        AirlineREntities2 db = new AirlineREntities2();
        public BookingController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>
        public IEnumerable<Booking_Details> Get()
        {
            return db.Booking_Details.ToList();
        }

        // GET api/<controller>/5
        public Booking_Details Get(int id)
        {
            return db.Booking_Details.Find(id);
        }
        [HttpGet]
        public IEnumerable<Booking_Details> Get([FromUri] string email)
        {
            var selectedUser = db.Booking_Details.Where(i => i.Email == email);
            return selectedUser;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Booking_Details bd)
        {
            try
            {
                db.Booking_Details.Add(bd);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Booking_Details bd)
        {
            try
            {
                if (id == bd.TicketNo)
                {
                    db.Entry(bd).State = System.Data.Entity.EntityState.Modified;
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
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Booking_Details b = db.Booking_Details.Find(id);
                if (b != null)
                {
                    db.Booking_Details.Remove(b);
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