﻿using System.Collections.Generic;
using KioskData.KioskModels;

namespace KioskData
{
    public interface IPersonRepository
    {
        IReadOnlyList<Person> RetrievePeople();

        void SavePerson(string name, string email, string password);
    }
}
