using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;

namespace AirlineRWebApi.Controllers
{
    public class ContactController : ApiController
    {
        AirlineREntities2 db = new AirlineREntities2();
        public ContactController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        // GET api/<controller>
        public IEnumerable<Contact> Get()
        {
            return db.Contacts.ToList();
        }

        // GET api/<controller>/5
        public Contact Get(int id)
        {
            return db.Contacts.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Contact co)
        {
            try
            {
                db.Contacts.Add(co);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Contact co)
        {
            try
            {
                if (id == co.ContactID)
                {
                    db.Entry(co).State = System.Data.Entity.EntityState.Modified;
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
                Contact c = db.Contacts.Find(id);
                if (c != null)
                {
                    db.Contacts.Remove(c);
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