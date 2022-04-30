using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; } = null; 

        public string Description { get; set; } = null;

        public Place(int placeId, string name, string address, string description)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
            Description = description;
        }

        public object Picture { get; set; } = null;

        public DateTime CreatedOn { get; private set; }
    }
}
