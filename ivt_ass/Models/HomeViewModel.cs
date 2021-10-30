using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ivt_ass.Models
{
    public class HomeViewModel
    {
        public List<Category> category { get; set; }
        public List<CServices> cServices { get; set; }
        public List<SubServices> subServices { get; set; }
        public List<Partners> partners { get; set; }

    }
}
