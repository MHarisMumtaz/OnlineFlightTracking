using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightQuery.Controllers
{
    public class AirportController : Controller
    {
        //
        // GET: /Airport/

        public ActionResult air()
        {
            return View("airportinfo");
        }

    }
}
