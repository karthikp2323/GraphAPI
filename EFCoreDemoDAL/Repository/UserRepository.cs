using EFCoreDemoDAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemoDAL.Repository
{
    public class UserRepository : GenericRepository<Roles>
    {
        public UserRepository(SampleContext _context) : base(_context)
        {
        }
    }
}
