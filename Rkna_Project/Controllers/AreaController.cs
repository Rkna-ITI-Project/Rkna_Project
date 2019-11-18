using Rkna_Project.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Rkna_Project.Controllers
{
    public class AreaController : Controller
    {

        // GET: Area 
        [Authorize(Roles = "admin,manger")]
        public ActionResult Index()
        {
            IEnumerable<Area_TableMeta> Area_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Area_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Area_Table");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Area_TableMeta>>();
                    readTask.Wait();

                    Area_TableMeta = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    Area_TableMeta = Enumerable.Empty<Area_TableMeta>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(Area_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult CreateArea()
        {   ////in this view i do a create view from Governorate_TableMeta class in metadata folder without using context_DB in view 
            List<States_TableMeta> StateList = new List<States_TableMeta>();
            SelectList list = new SelectList(StateList, "States_ID", "States_Name");
            ViewBag.List = list;
            return View();
        }

        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult CreateArea(Area_TableMeta Area_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Area_Table");
                var postTask = client.PostAsJsonAsync<Area_TableMeta>("Area_TableMeta", Area_TableMeta);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(Area_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult UpdateArea(int id)
        {
            List<States_TableMeta> StateList = new List<States_TableMeta>();
            SelectList list = new SelectList(StateList, "States_ID", "States_Name");
            ViewBag.List = list;
            Area_TableMeta Area_TableMeta = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Area_Table");
                //HTTP GET
                var responseTask = client.GetAsync("Area_Table?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Area_TableMeta>();
                    readTask.Wait();

                    Area_TableMeta = readTask.Result;
                }
            }
            return View(Area_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        [HttpPost]
        public ActionResult UpdateArea(Area_TableMeta Area_TableMeta)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Area_Table");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Area_TableMeta>("Area_Table", Area_TableMeta);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(Area_TableMeta);
        }

        [Authorize(Roles = "admin,manger")]
        public ActionResult deleteArea(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49993/api/Area_Table");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Area_Table/" + id.ToString());
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
