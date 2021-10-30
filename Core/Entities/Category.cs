using System;
using System.Collections.Generic;

namespace Core.Entities
{
  public  class Category : EntityBase
    {
        public String Cname { get; set; }
        public String Description { get; set; }
        public string ImageUrl { get; set; }
        //Navigation Properties
       // public List<Partners> Partners { get; set; }

    }
}
