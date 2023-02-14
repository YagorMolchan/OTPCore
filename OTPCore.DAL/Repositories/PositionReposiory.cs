using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.Interfaces;
using OTPCore.DAL.Entities;
using OTPCore.DAL.EFCore;
using Microsoft.EntityFrameworkCore;
namespace OTPCore.DAL.Repositories
{
    public class PositionReposiory:IPositionRepository
    {
        private readonly OTPDbContext _dbContext;

        public PositionReposiory(OTPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Position> GetAll()
        {
            return _dbContext.Positions.AsNoTracking().Include(p => p.Employees).ToList();
        }

        public Position Get(int id)
        {
            return _dbContext.Positions.AsNoTracking().Include(p => p.Employees).FirstOrDefault(p => p.Id == id);
        }

        public void Create(Position position)
        {
            _dbContext.Positions.Add(position);
        }

        public void Update(Position position)
        {
            _dbContext.Positions.Update(position);
        }

        public void Delete(Position position)
        {
            _dbContext.Positions.Remove(position);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
