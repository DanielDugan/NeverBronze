using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Linq;

namespace NeverBronze.Controllers
{
    public class ParticipantController : Controller
    {
        public ActionResult Index()
        {
            string filename = @"C:\Users\Joseph\Desktop\GitHub\NeverBronze\NeverBronze\NeverBronze\App_Data\data.json";
                
            using (var reader = new StreamReader(filename))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = new JsonSerializer();
                var match = serializer.Deserialize<Match>(jsonReader);

                ViewBag.FrameParticipants = new List<List<List<string>>>();

                foreach (var frame in match.timeline.frames)
                {
                    ViewBag.FrameParticipants.Add(frame.getAllFrameParticipants());
                }
            }

            return View();
        }
    }
}