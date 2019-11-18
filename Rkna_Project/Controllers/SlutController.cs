using Rkna_Project.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Rkna_Project.Controllers
{
    public class SlutController : Controller
    {
        // GET: Slut
        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            IEnumerable<Slut_TableMeta> Slut_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Slut_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Slut_Table");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Slut_TableMeta>>();
                    readTask.Wait();

                    Slut_TableMeta = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Slut_TableMeta = Enumerable.Empty<Slut_TableMeta>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Slut_TableMeta); 
        }
        [Authorize(Roles = "admin,manger")]
        public ActionResult CreateSlut()
        {   ////in this view i do a create view from Governorate_TableMeta class in metadata folder without using context_DB in view 
            return View();
        }
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult CreateSlut(Slut_TableMeta Slut_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Slut_Table");
                var postTask = client.PostAsJsonAsync<Slut_TableMeta>("Slut_TableMeta", Slut_TableMeta);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Slut_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult UpdateSlut(int id)
        {
            Slut_TableMeta Slut_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Slut_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Slut_Table?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Slut_TableMeta>();
                    readTask.Wait();

                    Slut_TableMeta = readTask.Result;
                }
            }
            return View(Slut_TableMeta);
        }
        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult UpdateSlut(Slut_TableMeta Slut_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Slut_Table");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Slut_TableMeta>("Slut_Table", Slut_TableMeta);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Slut_TableMeta);
        }


        [Authorize(Roles = "admin,manger")]
        public ActionResult deleteSlut(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Slut_Table");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Slut_Table/" + id.ToString());
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