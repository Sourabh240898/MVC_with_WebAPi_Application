using MVC_with_WebAPi_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;




namespace MVC_with_WebAPi_Application.Controllers
{
    public class ConsumeWebApiMVCController : Controller
    {
        // GET: ConsumeWebApiMVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Item> list = new List<Item>();
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.GetAsync("Items");
            Response.Wait();

            var Test = Response.Result;
            if (Test.IsSuccessStatusCode)
            {
                var Display = Test.Content.ReadAsAsync<List<Item>>();
                Display.Wait();
                list = Display.Result;
            }
            return View(list);
           
        }

        //Create Post (Insert)
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        
        [HttpPost]
        public ActionResult Create(Item item)
        {
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.PostAsJsonAsync<Item>("Items", item);
            Response.Wait();
            var Test = Response.Result;

            if (Test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Create");

        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Item i = new Item();
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.GetAsync("Items?id=" + id.ToString());
            Response.Wait();
            var Test = Response.Result;
            if (Test.IsSuccessStatusCode)
            {
                var display = Test.Content.ReadAsAsync<Item>();
                display.Wait();
                i = display.Result;

            }
            return View(i);
        }
        [HttpGet]
        public ActionResult Edit(int id)    //Edit-get Records on view to update.
        {
            Item i = new Item();
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.GetAsync("Items?id="+id.ToString());
            Response.Wait();
            var Test = Response.Result;
            if (Test.IsSuccessStatusCode)
            {
                var display = Test.Content.ReadAsAsync<Item>();
                display.Wait();
                i = display.Result;

            }
            return View(i);

        }

       
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.PutAsJsonAsync<Item>("Items", item);
            Response.Wait();

            var Test = Response.Result;
            if (Test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Edit");

        }

        [HttpGet]
        public ActionResult Delete(int id)   //Delete - Get records on view to delete with id
        {
            Item i = new Item();
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.GetAsync("Items?id=" + id.ToString());
            Response.Wait();
            var Test = Response.Result;

            if (Test.IsSuccessStatusCode)
            {
                var Display = Test.Content.ReadAsAsync<Item>();
                Display.Wait();
                i = Display.Result;

            }
            return View(i);

        }
        
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Item i = new Item();
            client.BaseAddress = new Uri("https://localhost:44322/api/Items");
            var Response = client.DeleteAsync("Items?id=" + id.ToString());
            Response.Wait();
            var Test = Response.Result;

            if (Test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Delete");


        }



    }
}