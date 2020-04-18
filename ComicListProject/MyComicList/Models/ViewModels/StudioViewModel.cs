using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyComicList.Models.ViewModels
{
    public class StudioViewModel : ViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        // MARK:- Many-to-Many Relationships
        public StudioViewModel() : base() { }

        public StudioViewModel(Studio studio) : base(studio)
        {
            Name = studio.Name;
            Location = studio.Location;
        }

        public static List<StudioViewModel> ToList(List<Studio> studios)
        {
            List<StudioViewModel> studioViewModels = new List<StudioViewModel>();
            foreach (Studio studio in studios)
            {
                StudioViewModel studioViewModel = new StudioViewModel(studio);
                studioViewModels.Add(studioViewModel);
            }
            return studioViewModels;
        }
    }
}