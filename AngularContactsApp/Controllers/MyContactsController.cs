using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AngularContactsApp.Models;

namespace AngularContactsApp.Controllers
{
    public class MyContactsController : ApiController
    {
        private MyContactsContext db = new MyContactsContext();

        // GET api/MyContacts
        public IEnumerable<MyContacts> GetMyContacts()
        {
            return db.MyContacts.AsEnumerable();
        }

        // GET api/MyContacts/5
        public MyContacts GetMyContacts(int id)
        {
            MyContacts mycontacts = db.MyContacts.Find(id);
            if (mycontacts == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mycontacts;
        }

        // PUT api/MyContacts/5
        public HttpResponseMessage PutMyContacts(int id, MyContacts mycontacts)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != mycontacts.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(mycontacts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/MyContacts
        public HttpResponseMessage PostMyContacts(MyContacts mycontacts)
        {
            if (ModelState.IsValid)
            {
                db.MyContacts.Add(mycontacts);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mycontacts);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mycontacts.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/MyContacts/5
        public HttpResponseMessage DeleteMyContacts(int id)
        {
            MyContacts mycontacts = db.MyContacts.Find(id);
            if (mycontacts == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.MyContacts.Remove(mycontacts);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mycontacts);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}