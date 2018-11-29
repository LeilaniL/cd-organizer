using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;
using System.Collections.Generic;

namespace CDOrganizer.Controllers
{
    public class AlbumsController : Controller
    {
        [HttpGet("/artists/{artistId}/albums/new")]
        public ActionResult New(int artistId)
        {
            Artist artist = Artist.Find(artistId);
            return View(artist);
        }

        [HttpPost("/albums")]
        public ActionResult Create(string description)
        {
            Album myAlbum = new Album(description);
            return RedirectToAction("Index");
        }

        [HttpPost("/albums/delete")]
        public ActionResult DeleteAll()
        {
            Album.ClearAll();
            return View();
        }
        [HttpGet("/artists/{artistId}/albums/{albumId}")]
        public ActionResult Show(int artistId, int albumId)
        {
            Album album = Album.Find(albumId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist artist = Artist.Find(artistId);
            model.Add("album", album);
            model.Add("artist", artist);
            return View(model);
        }
    }
}
