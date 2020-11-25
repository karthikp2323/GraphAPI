using EFCoreDemoDAL.IRepository;
using EFCoreDemoDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoDAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleContext _context;


        public UnitOfWork(SampleContext context)
        {
            _context = context;
            RoleRespository = new GenericRepository<Roles>(_context);
            UserRepository = new UserRepository(_context);
          
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //regester all our repositories here
        public UserRepository UserRepository { get; set; }

        public GenericRepository<Roles> RoleRespository { get; set; }
        
    }
}
