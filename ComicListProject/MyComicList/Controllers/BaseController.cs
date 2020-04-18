using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories;
using DataStructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyComicList.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyComicList.Controllers
{
    [Authorize]
    public class BaseController<T> : Controller where T : Model
    {
        readonly private GenericRepository<T> repository;

        public UnitOfWork uow = UnitOfWork.Main;

        public const int pageSize = 4;


        public BaseController(GenericRepository<T> repository)
        {
            this.repository = repository;
        }
        // ne raboti oshte //

        //[Authorize(Roles = "admin")]
        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        public int CalculatePagesCount<K>(List<K> entities) where K : ViewModel
        {
            return (int)Math.Ceiling(((double)entities.Count / (double)pageSize) - 1);
        }

        public int CalculateCurrentPageNumber(int? page, int maxPages)
        {
            int currentPage = page ?? 0;

            if (page != null)
            {
                if (page < 0)
                {
                    currentPage = 0;
                }
                else if (page > maxPages - 1)
                {
                    currentPage = maxPages;
                }
            }

            return currentPage;
        }
    }
}
