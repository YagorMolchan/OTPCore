using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.EFCore;

namespace OTPCore.DAL.Interfaces
{
    public interface IOTPUnitOfWork:IDisposable
    {
        IEmployeeRepository Employees { get; }

        IPositionRepository Positions { get; }

        OTPDbContext Context { get;  }

        void Save();
    }
}
