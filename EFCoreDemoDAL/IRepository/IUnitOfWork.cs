using EFCoreDemoDAL.Model;
using EFCoreDemoDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoDAL.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();

        UserRepository UserRepository { get; }

        GenericRepository<Roles> RoleRespository { get; }

    }
}
