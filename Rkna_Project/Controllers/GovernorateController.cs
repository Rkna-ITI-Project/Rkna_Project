using Rkna_Project.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Rkna_Project.Controllers
{
    public class GovernorateController : Controller
    {

        // GET: Governorate
        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            IEnumerable<Governorate_TableMeta> Governorate_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Governorate_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Governorate_Table");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Governorate_TableMeta>>();
                    readTask.Wait();

                    Governorate_TableMeta = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Governorate_TableMeta = Enumerable.Empty<Governorate_TableMeta>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Governorate_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult CreateGovernorator()
        {   ////in this view i do a create view from Governorate_TableMeta class in metadata folder without using context_DB in view 
            return View();
        }
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult CreateGovernorator(Governorate_TableMeta Governorate_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Governorate_Table");
                var postTask = client.PostAsJsonAsync<Governorate_TableMeta>("Governorate_TableMeta", Governorate_TableMeta);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }

            return View(Governorate_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult UpdateGovernorator(int id)
        {
            Governorate_TableMeta Governorate_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Governorate_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Governorate_Table?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Governorate_TableMeta>();
                    readTask.Wait();

                    Governorate_TableMeta = readTask.Result;
                }
            }
            return View(Governorate_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult UpdateGovernorator(Governorate_TableMeta Governorate_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Governorate_Table");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Governorate_TableMeta>("Governorate_Table", Governorate_TableMeta);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Governorate_TableMeta);
        }


        [Authorize(Roles = "admin,manger")]
        public ActionResult deleteGovernorator(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Governorate_Table");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Governorate_Table/" + id.ToString());
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

