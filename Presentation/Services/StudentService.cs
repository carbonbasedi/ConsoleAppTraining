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
    internal class StudentService
    {
        private readonly StudentRepos _studentRepos;
        public StudentService()
        {
             _studentRepos= new StudentRepos();
        }
        public bool Exit()
        {
            return true;
        }

        public void Create()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
        public void GetAll() 
        {

        }

    }
}
