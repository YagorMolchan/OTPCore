using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.Entities;

namespace OTPCore.DAL.Interfaces
{
    public interface IPositionRepository
    {
        List<Position> GetAll();

        Position Get(int id);

        void Create(Position position);

        void Update(Position position);

        void Delete(Position position);
    }
}
