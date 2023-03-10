using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos.Abstract
{
    internal interface IGroupRepos
    {
        List<Group> GetAll();
        Group Get(int id);
        Group GetByName(string name);
        void Add(Group group);
        void Update(Group group);
        void Delete(Group group);
    }
}
