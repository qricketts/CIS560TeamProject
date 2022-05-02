using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskData.KioskModels
{
    public class Place
    {
        private int _categoryId; 
        public int CategoryId
        {
            get => _categoryId;
            set => _categoryId = value; 
        }
        private int _placeId; 
        public int PlaceId
        {
            get => _placeId;
            set => _placeId = value; 
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value; 
        }

        private string _address; 
        public string Address
        {
            get => _address;
            set => _address = value; 
        }

        private string _description; 
        public string Description
        {
            get => _description;
            set => _description = value; 
        }

        public Place(int placeId, int categoryId, string name, string address, string description)
        {
            PlaceId = placeId;
            CategoryId = categoryId; 
            Name = name;
            Address = address;
            Description = description;

        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get => _createdOn;
            set => _createdOn = value;
        }

        private DateTime _updatedOn;
        public DateTime UpdatedOn
        {
            get => _updatedOn;
            set => _updatedOn = value;
        }
    }
}
