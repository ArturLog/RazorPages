using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Interfaces
{
    public interface ICrudOperations
    {
        bool Add();
        bool Delete();
        bool Update();
        IBaseEntity GetById(int id);
    }
}
