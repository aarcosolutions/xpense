using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xpense.Contract.Repository;

namespace xpense.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected XpenseDbContext _context { get; }

        public BaseRepository(XpenseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
