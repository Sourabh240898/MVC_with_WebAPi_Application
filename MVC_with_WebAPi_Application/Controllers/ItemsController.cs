using MVC_with_WebAPi_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_with_WebAPi_Application.Controllers
{
    public class ItemsController : ApiController
    {
       public WebAPIDbEntities _db = new WebAPIDbEntities();

        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            var Data = _db.Items.ToList();
            return Ok(Data);
        }
        [HttpGet]
        public IHttpActionResult GetItemById(int id)
        {
            var Data = _db.Items.FirstOrDefault(x => x.Id == id);
            return Ok(Data);

        }

        [HttpPost]
        public IHttpActionResult ItemInsert(Item i)
        {
            _db.Items.Add(i);
            _db.SaveChanges();
            return Ok();

        }
        [HttpPut]
        public IHttpActionResult ItemUpdate(Item i) 
        {
            _db.Entry(i).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult ItemDelete(int id) 
        {
            var Data = _db.Items.FirstOrDefault(x => x.Id == id);
            _db.Entry(Data).State = System.Data.Entity.EntityState.Deleted;
            _db.SaveChanges();
            return Ok();
        
        }

    }
}
