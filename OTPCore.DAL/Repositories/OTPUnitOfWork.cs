using Microsoft.EntityFrameworkCore;
using OTPCore.DAL.EFCore;
using OTPCore.DAL.Interfaces;
using OTPCore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.DAL.Repositories
{
    public class OTPUnitOfWork : IOTPUnitOfWork
    {
        private readonly OTPDbContext _dbContext;
        private IEmployeeRepository _employees;
        private IPositionRepository _positions;

        public OTPUnitOfWork(OTPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if(_employees == null)
                {
                    _employees = new EmployeeRepository(_dbContext);
                }

                return _employees;
            }
        }

        public IPositionRepository Positions
        {
            get
            {
                if (_positions == null)
                {
                    _positions = new PositionReposiory(_dbContext);
                }

                return _positions;
            }
        }

        public OTPDbContext Context
        {
            get
            {
                return _dbContext;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    
}
