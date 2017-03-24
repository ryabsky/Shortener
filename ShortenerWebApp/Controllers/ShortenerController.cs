using System.Linq;
using System.Web.Mvc;
using ShortenerWebApp.Models;

namespace ShortenerWebApp.Controllers
{
    public class ShortenerController : Controller
    {
        private readonly DataAccessLayer.LinkRepository repository = new DataAccessLayer.LinkRepository();
        [HttpGet]
        public ActionResult Index()
        {
            return View("ShortenerIndex");
        }

        [HttpPost]
        public ActionResult SaveLink(Link link)
        {
            var saved = repository.SaveLink(link.Url);
            var links = repository.GetLinks();

            return Json(new
            {
                SavedLink = new Link { Url = link.Url, ShortUrl = saved.ShortUrl, Clicks = 0},
                ExistingLinks = links.Select(x => new Link { Url = x.Url, ShortUrl = x.ShortUrl, Clicks = x.Clicks}).ToArray()
            });
        }

        [HttpPost]
        public ActionResult GetLinks()
        {
            var links = repository.GetLinks();
            return Json(new
            {
                ExistingLinks = links.Select(x => new Link {Url = x.Url, ShortUrl = x.ShortUrl, Clicks = x.Clicks }).ToArray()
            });
        }

    }
}