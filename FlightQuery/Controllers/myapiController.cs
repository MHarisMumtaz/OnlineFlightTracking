using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using System.IO;
using System.Web.Script.Serialization;

namespace FlightQuery.Controllers
{
    public class myapiController : ApiController
    {
        // GET api/myapi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/myapi/5
        public string Get(string id)
        {
            string url = @"https://api.flightstats.com/flex/flightstatus/rest/v2/json/airport/status/"+id+"/dep/"+DateTime.Now.Year+"/"+DateTime.Now.Month+"/"+DateTime.Now.Day+"/23?appId=f997f7d8&appKey=15e4c7c192293f39dd63b8d05c9e2bbc&utc=true&numHours=6";
            string endPoint = @"https://api.flightstats.com/flex/airports/rest/v1/json/cityCode/" + id + "?appId=f997f7d8&appKey=d6a881e992c00736d830ec6242f9514f";
            var client = new RestClient(url);
            var json = client.MakeRequest();
           json= json.Replace('\\', ' ');
           json= json.Replace('\"', ' ');
            string[] aa = json.Split('[');
            string flightstatus = aa[4];
            JavaScriptSerializer s = new JavaScriptSerializer();
            List<Models.flightstatus> collection = s.Deserialize<List<Models.flightstatus>>(json);
            return "value";

        }

        // POST api/myapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/myapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/myapi/5
        public void Delete(int id)
        {
        }
    }
}
