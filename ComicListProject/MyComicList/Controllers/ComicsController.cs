using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyComicList.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyComicList.Controllers
{
    public class ComicsController : BaseController<Comic>
    {
        public ComicsController() : base(UnitOfWork.Main.ComicRepository) { }

        public ActionResult Index(string queryString)
        {
            List<Comic> comics;
            if (queryString != null && queryString != "")
            {
                comics = uow.ComicRepository.SearchBy(queryString);
            }
            else
            {
                comics = uow.ComicRepository.GetAll();
            }
            List<ComicViewModel> comicViewModels = ComicViewModel.ToList(comics);
            return View(comicViewModels);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            Comic comic = uow.ComicRepository.GetByID((int)id);

            ComicViewModel comicViewModel = new ComicViewModel(comic);
            return View(comicViewModel);
        }

        public ActionResult Create()
        {
            List<OriginViewModel> origins = OriginViewModel.ToList(uow.OriginRepository.GetAll());
            ViewBag.Origins = new SelectList(origins, "ID", "Name");

            List<GenreViewModel> genres = GenreViewModel.ToList(uow.GenreRepository.GetAll());
            ViewBag.Genres = new MultiSelectList(genres, "ID", "Type");


            List<StudioViewModel> studios = StudioViewModel.ToList(uow.StudioRepository.GetAll());
            ViewBag.Studios = new MultiSelectList(studios, "ID", "Name");

            return View();
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            Comic comic = uow.ComicRepository.GetByID((int)id);
            ComicViewModel comicViewModel = new ComicViewModel(comic);

            List<OriginViewModel> origins = OriginViewModel.ToList(uow.OriginRepository.GetAll());
            ViewBag.Origins = new SelectList(origins, "ID", "Name");

            List<GenreViewModel> genres = GenreViewModel.ToList(uow.GenreRepository.GetAll());
            ViewBag.Genres = new MultiSelectList(genres, "ID", "Type");


            List<StudioViewModel> studios = StudioViewModel.ToList(uow.StudioRepository.GetAll());
            ViewBag.Studios = new MultiSelectList(studios, "ID", "Name");

            return View(comicViewModel);
        }

        //[Authorize(Roles = "admin")]
        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            Comic comic = uow.ComicRepository.GetByID((int)id);
            ComicViewModel comicViewModel = new ComicViewModel(comic);


            List<OriginViewModel> origins = OriginViewModel.ToList(uow.OriginRepository.GetAll());
            ViewBag.Origins = new SelectList(origins, "ID", "Name");

            List<GenreViewModel> genres = GenreViewModel.ToList(uow.GenreRepository.GetAll());
            ViewBag.Genres = new MultiSelectList(genres, "ID", "Type");


            List<StudioViewModel> studios = StudioViewModel.ToList(uow.StudioRepository.GetAll());
            ViewBag.Studios = new MultiSelectList(studios, "ID", "Name");

            return View(comicViewModel);
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComicViewModel comicViewModel) // [Bind(Include = "ID,Title,Volumes,ImageUrl,ImageThumnail,IsPopularComic,IsCompletedComic,GenreID,StudioIDs,OriginID,CreatedAt,UpdatedAt")]
        {
            if (ModelState.IsValid)
            {
                Comic comic = Transform(comicViewModel);
                uow.ComicRepository.CreateOrUpdate(comic);
                return RedirectToAction("Index");
            }

            return View(comicViewModel);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComicViewModel comicViewModel)
        {
            if (ModelState.IsValid)
            {
                Comic comic = Transform(comicViewModel);
                uow.ComicRepository.CreateOrUpdate(comic);
                return RedirectToAction("Index");
            }
            return View(comicViewModel);
        }

        private Comic Transform(ComicViewModel comicViewModel)
        {
            return new Comic()
            {
                ID = comicViewModel.ID,
                Title = comicViewModel.Title,
                Volumes = comicViewModel.Volumes,
                ImageUrl = comicViewModel.ImageUrl,
                ImageThumbnailUrl = comicViewModel.ImageThumbnailUrl,
                IsPopularComic = comicViewModel.IsPopularComic,
                IsCompletedComic = comicViewModel.IsCompletedComic,
                //Genres = uow.GenreRepository.GetByID(comicViewModel.GenreIDs),
                //Studios = uow.StudioRepository.GetByID(comicViewModel.StudiosIDs),
                Origin = uow.OriginRepository.GetByID(comicViewModel.OriginID),
                CreatedAt = comicViewModel.CreatedAt,
                UpdatedAt = comicViewModel.UpdatedAt,
            };
        }

    }
}

