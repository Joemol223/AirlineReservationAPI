using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;


namespace AirlineRWebApi.Controllers
{
    public class CancelController : ApiController
    {
        AirlineREntities2 db = new AirlineREntities2();
        public CancelController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>
        public IEnumerable<Cancel> Get()
        {
            return db.Cancels.ToList();
        }

        // GET api/<controller>/5
        public Cancel Get(int id)
        {
            return db.Cancels.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Cancel ca)
        {
            try
            {
                db.Cancels.Add(ca);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Cancel ca)
        {
            try
            {
                if (id == ca.CancelNo)
                {
                    db.Entry(ca).State = System.Data.Entity.EntityState.Modified;
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
                Cancel c = db.Cancels.Find(id);
                if (c != null)
                {
                    db.Cancels.Remove(c);
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