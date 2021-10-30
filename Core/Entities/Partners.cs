using System;

namespace Core.Entities
{
   public class Partners : EntityBase
    {
        public String PName { get; set; }
        public String PEmail { get; set; }

        public int PPhone { get; set; }

        //Navigation Properties
        public String categoryName  { get; set; }
      
    }
}
