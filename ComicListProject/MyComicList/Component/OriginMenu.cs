using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Components
{
    public class OriginMenu: ViewComponent
    {
        private readonly IOriginRepository _originRepository;
        public OriginMenu(IOriginRepository originRepository)
        {
            _originRepository = originRepository;
        }

        public IViewComponentResult Invoke()
        {
            var origins = _originRepository.Origins.OrderBy(p => p.Name);
            return View(origins);
        }
    }
}
