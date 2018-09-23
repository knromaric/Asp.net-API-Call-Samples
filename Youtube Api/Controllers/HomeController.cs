using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Youtube_Api.Models;

namespace Youtube_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = "YourAPIKey";
            string query = "plethor";

            //create the request to the api
            WebRequest request = WebRequest.Create("https://www.googleapis.com/youtube/v3/search?part=snippet&q="+ query + "&key="+ apiKey);
            //set that request off
            WebResponse response = request.GetResponse();
            //get back the response stream
            Stream stream = response.GetResponseStream();
            //make it accessible
            StreamReader reader = new StreamReader(stream);
            //put into string, which is json format file
            string responseFromServer = reader.ReadToEnd();

            JObject parseString = JObject.Parse(responseFromServer);

            YoutubeSearch youtubeResult = parseString.ToObject<YoutubeSearch>();
          
            return View(youtubeResult);
        }

    }
}