using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskModels.KioskModels
{
    public class Rating
    {
        public int Rate { get; set; }
        public Place Place { get; set; }
        public Person Person { get; set; }
        public DateTime CreatedOn { get; private set; }

        public Rating(int rating)
        {
            Rate = rating;
            CreatedOn = DateTime.Now; 
        }
    }
}
