using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartCocktails.Models;

namespace SmartCocktails.Controllers
{

    public class ConstituentsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET api/values
        public IEnumerable<Constituent> Get()
        {
            return db.Constituents;
        }

        // GET api/values/5
        public Constituent Get(int id)
        {
            return db.Constituents.First(c => c.Id == id);
        }

        // POST api/values
        public void Post([FromBody]Constituent value)
        {
            if (ModelState.IsValid)
            {
                db.Constituents.Add(value);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Constituent value)
        {
            if (value.Id == id)
            {
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Constituent constituent = db.Constituents.Find(id);
            if (constituent != null)
            {
                db.Constituents.Remove(constituent);
                db.SaveChanges();
            }
        }
    }
}
