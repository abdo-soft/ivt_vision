using System;

namespace Core.Entities
{
   public class CServices : EntityBase
    {
        public String Sname { get; set; }
        public int Price { get; set; }

        public String Duration { get; set; }
        public string ImageUrl { get; set; }
        public SubServices SubServices { get; set; }
    }
}
