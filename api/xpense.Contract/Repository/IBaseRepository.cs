using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xpense.Contract.Repository
{
    public interface IBaseRepository
    {
        Task Save();
    }
}
