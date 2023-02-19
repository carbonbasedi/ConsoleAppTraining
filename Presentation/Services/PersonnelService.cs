using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;
using Data.Repos.Actual;

namespace Presentation.Services
{
    internal class PersonnelService
    {
        private readonly PersonnelRepos _personnelRepos;
        public PersonnelService()
        {
            _personnelRepos = new PersonnelRepos();
        }

    }
}
