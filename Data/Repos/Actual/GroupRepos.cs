using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Data.Repos.Abstract;
using Data.Context;

namespace Data.Repos.Actual
{
    public class GroupRepos : IGroupRepos
    {
        static int id;
        public List<Group> GetAll()
        {
            return DbContext.Groups;
        }
        public Group Get(int id)
        {
            return DbContext.Groups.FirstOrDefault(q => q.Id == id);
        } 
        public Group Get(string name)
        {
            return DbContext.Groups.FirstOrDefault(q => q.Name == name);
        }

        public void Add(Group group)
        {
            id++;
            group.Id = id;
            group.CreatedAt= DateTime.Now;
            DbContext.Groups.Add(group);
        }
        public void Update(Group group)
        {
            throw new NotImplementedException();
        }
        public void Delete(Group group)
        {
            DbContext.Groups.Remove(group);
        }
    }
}
