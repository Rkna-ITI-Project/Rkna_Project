using Rkna_Project.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Rkna_Project.Controllers
{
    public class StatesController : Controller
    {
        // GET: states
        public ActionResult Index()
        {
            IEnumerable<States_TableMeta> States_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/States_Table");
                //HTTP GET
                var responseTask = client.GetAsync("States_Table");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<States_TableMeta>>();
                    readTask.Wait();

                    States_TableMeta = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    States_TableMeta = Enumerable.Empty<States_TableMeta>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(States_TableMeta);
        }
        public ActionResult CreateStates()
        {   ////in this view i do a create view from Governorate_TableMeta class in metadata folder without using context_DB in view 
            return View();
        }
        [HttpPost]
        public ActionResult CreateStates(States_TableMeta States_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/States_Table");
                var postTask = client.PostAsJsonAsync<States_TableMeta>("States_TableMeta", States_TableMeta);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(States_TableMeta);
        }

        public ActionResult UpdateStates(int id)
        {
            States_TableMeta States_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/States_Table");
                //HTTP GET
                var responseTask = client.GetAsync("States_Table?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<States_TableMeta>();
                    readTask.Wait();

                    States_TableMeta = readTask.Result;
                }
            }
            return View(States_TableMeta);
        }
        [HttpPost]
        public ActionResult UpdateStates(States_TableMeta States_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/States_Table");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<States_TableMeta>("States_Table", States_TableMeta);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(States_TableMeta);
        }


        public ActionResult deleteStates(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/States_Table");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("States_Table/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}