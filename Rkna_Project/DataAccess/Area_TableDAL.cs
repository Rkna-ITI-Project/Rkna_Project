using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using Rkna_Project.MetaData;
using System.Net.Http;
using System.Net;

namespace Rkna_Project.DataAccess
{
    public class Area_TableDAL
    {
        public static List<Area_TableMeta> GetArea_TableMeta()
        {
            try
            {
                var resultList = new List<Area_TableMeta>();
                var Client = new HttpClient();
                var getDataTask = Client.GetAsync("http://localhost:49993/api/Area_Table").ContinueWith(response =>         ////localhost دة بنجيبة لما نعمل رن لل ابى اى////emp is the name of class
                {
                    var result = response.Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        var resultReader = result.Content.ReadAsAsync<List<Area_TableMeta>>();
                        resultReader.Wait();
                        resultList = resultReader.Result;
                    }
                });
                getDataTask.Wait();
                return resultList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}