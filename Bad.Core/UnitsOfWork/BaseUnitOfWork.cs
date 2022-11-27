using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bad.Core.UnitsOfWork
{
    public class BaseUnitOfWork
    {
        private readonly DbContext _context;

        public BaseUnitOfWork(DbContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
