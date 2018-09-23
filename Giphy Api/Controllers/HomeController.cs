using Giphy_Api.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Giphy_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = WebConfigurationManager.AppSettings["gliphyAPIKey"];
            string query = "pokemon";
            int offset = 0; 
            //create the request to the api
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q="+ query + "&api_key=" + apiKey + "&offset="+ offset);
            //set that request off
            WebResponse response = request.GetResponse();
            //get back the response stream
            Stream stream = response.GetResponseStream();
            //make it accessible
            StreamReader reader = new StreamReader(stream);
            //put into string, which is json format file
            string responseFromServer = reader.ReadToEnd();

            JObject parseString = JObject.Parse(responseFromServer);

            Gif myGifs = parseString.ToObject<Gif>(); 
           
            return View(myGifs);
        }

     
    }
}