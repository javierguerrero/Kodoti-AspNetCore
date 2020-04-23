using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KODOTI_MVC.Views.Shared.Components.LastNews.Models
{
    public class LastNewsPostModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
