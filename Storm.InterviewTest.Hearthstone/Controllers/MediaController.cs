using System.Configuration;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Media.Services;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
        private readonly string localMediaPath;

        public MediaController()
        {
            localMediaPath = ConfigurationManager.AppSettings["LocalMediaPath"];
        }

        public ActionResult Card(string id)
        {
            var mediaService = new MediaService(Server.MapPath(localMediaPath));
            var filePath = mediaService.GetCardPath(id);

            return filePath == null ? null : File(filePath, "image/png");
        }
    }
}