using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeverBronze.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            string filename = @"C:\Users\Joseph\Desktop\GitHub\NeverBronze\NeverBronze\NeverBronze\App_Data\data.json";

            using (var reader = new StreamReader(filename))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = new JsonSerializer();
                var match = serializer.Deserialize<Match>(jsonReader);

                ViewBag.FrameEvents = new List<List<List<string>>>();

                foreach (var frame in match.timeline.frames)
                {
                    ViewBag.FrameEvents.Add(frame.getAllFrameEvents());
                }
            }

            return View();
        }
    }
}