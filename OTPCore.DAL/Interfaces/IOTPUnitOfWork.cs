using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.DAL.Interfaces
{
    public interface IOTPUnitOfWork:IDisposable
    {
        IEmployeeRepository Employees { get; }

        IPositionRepository Positions { get; }

        void Save();
    }
}
