using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KODOTI_MVC.ViewModels
{
    public class AboutUsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Collaborators { get; set; }
    }
}
