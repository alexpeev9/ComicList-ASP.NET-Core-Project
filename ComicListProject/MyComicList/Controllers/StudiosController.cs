using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Controllers
{
    public class StudiosController : BaseController<Studio>
    {
        public StudiosController() : base(UnitOfWork.Main.StudioRepository) { }

        public ActionResult Index(string queryString)
        {
            List<Studio> studios;

            if (queryString != null && queryString != "")
            {
                studios = uow.StudioRepository.SearchBy(queryString);
            }
            else
            {
                studios = uow.StudioRepository.GetAll();
            }

            List<StudioViewModel> studioViewModels = StudioViewModel.ToList(studios);

            //int maxPages = this.CalculatePagesCount(studioViewModels);
            //int currentPage = this.CalculateCurrentPageNumber(page, maxPages);

            //ViewBag.Page = currentPage;
            //ViewBag.Max = maxPages;

            return View(studioViewModels);
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            Studio studio = uow.StudioRepository.GetByID((int)id);
            StudioViewModel studioViewModel = new StudioViewModel(studio);
            return View(studioViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            Studio studio = uow.StudioRepository.GetByID((int)id);
            StudioViewModel studioViewModel = new StudioViewModel(studio);
            return View(studioViewModel);
        }

        //[Authorize(Roles = "admin")]
        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            Studio studio = uow.StudioRepository.GetByID((int)id);
            StudioViewModel studioViewModel = new StudioViewModel(studio);
            return View(studioViewModel);
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudioViewModel studioViewModel)
        {
            if (ModelState.IsValid)
            {
                Studio studio = Transform(studioViewModel);
                uow.StudioRepository.CreateOrUpdate(studio);
                return RedirectToAction("Index");
            }
            return View(studioViewModel);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudioViewModel studioViewModel)
        {
            if (ModelState.IsValid)
            {
                Studio studio = Transform(studioViewModel);
                uow.StudioRepository.CreateOrUpdate(studio);
                return RedirectToAction("Index");
            }
            return View(studioViewModel);
        }

        public Studio Transform(StudioViewModel studioViewModel)
        {
            return new Studio()
            {
                ID = studioViewModel.ID,
                Name = studioViewModel.Name,
                Location = studioViewModel.Location,
                CreatedAt = studioViewModel.CreatedAt,
                UpdatedAt = studioViewModel.UpdatedAt
            };
        }
    }
}
