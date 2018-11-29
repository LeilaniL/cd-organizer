using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
    public class ArtistsController : Controller
    {
        [HttpGet("/artists")]
        public ActionResult Index()
        {
            List<Artist> allArtists = Artist.GetAll();
            return View(allArtists);
        }
        [HttpGet("/artists/new")]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost("/artists")]
        public ActionResult Create(string artistName)
        {
            Artist newArtist = new Artist(artistName);
            List<Artist> allArtists = Artist.GetAll();
            return View("Index", allArtists);
        }
        [HttpGet("/artists/search")]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost("/searchForm")]
        public ActionResult Search(string search)
        {
            int id = Artist.GetArtist(search);
            return RedirectToAction("Show", new { id = id });
        }

        [HttpGet("/artists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist selectedArtist = Artist.Find(id);
            List<Album> artistAlbums = selectedArtist.GetAlbums();
            model.Add("artist", selectedArtist);
            model.Add("albums", artistAlbums);
            return View(model);
        }
        // This one creates new Albums within a given Artist, not new artists:
        [HttpPost("/artists/{artistId}/albums")]
        public ActionResult Create(int artistId, string albumDescription)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist foundArtist = Artist.Find(artistId);
            Album newAlbum = new Album(albumDescription);
            foundArtist.AddAlbum(newAlbum);
            List<Album> artistAlbums = foundArtist.GetAlbums();
            model.Add("albums", artistAlbums);
            model.Add("artist", foundArtist);
            return View("Show", model);
        }



    }
}