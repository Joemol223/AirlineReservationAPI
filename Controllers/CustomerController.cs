using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AirlineRWebApi.Models;


namespace AirlineRWebApi.Controllers
{
   
    public class CustomerController : ApiController
    {
        AirlineREntities2 db = new AirlineREntities2();
        public CustomerController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
       
        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }

        // GET api/<controller>/5
        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Customer cu)
        {
            try
            {
                db.Customers.Add(cu);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Customer cu)
        {
            try
            {
                if (id == cu.Cid)
                {
                    db.Entry(cu).State = System.Data.Entity.EntityState.Modified;
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
                Customer c = db.Customers.Find(id);
                if (c != null)
                {
                    db.Customers.Remove(c);
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