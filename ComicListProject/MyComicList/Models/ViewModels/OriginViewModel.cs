using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class OriginViewModel : ViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FlagUrl { get; set; }

        public OriginViewModel() : base() { }

        public OriginViewModel(Origin origin) : base(origin)
        {
            Name = origin.Name;
            FlagUrl = origin.FlagUrl;
        }

        public static List<OriginViewModel> ToList(List<Origin> origins)
        {
            List<OriginViewModel> originViewModels = new List<OriginViewModel>();
            foreach (Origin origin in origins)
            {
                OriginViewModel originViewModel = new OriginViewModel(origin);
                originViewModels.Add(originViewModel);
            }
            return originViewModels;
        }
    }
}