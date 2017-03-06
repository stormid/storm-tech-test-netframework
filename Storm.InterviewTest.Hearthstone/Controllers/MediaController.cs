using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
        private MediaProvider _mediaProvider;
        // GET: Media
        public ActionResult Card(string id)
        {
            if(_mediaProvider == null)
            {
                var localBaseDirectory = Server.MapPath("~/App_Data/media/");
                _mediaProvider = new MediaProvider(localBaseDirectory, ConfigurationManager.AppSettings["MediaSource"]);
            }

            return File(_mediaProvider.GetFilePath(id), "image/png");  
		}
    }
}