using System.Net;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using Pokemon_Api.Models;
using System.Diagnostics;

namespace Pokemon_Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //create the request to the api
            WebRequest request = WebRequest.Create("https://pokeapi.co/api/v2/pokemon/777/");
            //set that request off
            WebResponse response = request.GetResponse();
            //get back the response stream
            Stream stream = response.GetResponseStream();
            //make it accessible
            StreamReader reader = new StreamReader(stream);
            //put into string, which is json formatted
            string responseFromServer = reader.ReadToEnd();

            JObject parseString = JObject.Parse(responseFromServer);
            Pokemon myPokemon = parseString.ToObject<Pokemon>();
           
            //Debug.WriteLine(myPokemon.moves[0].move.name);

            return View(myPokemon);
        }

    }
}