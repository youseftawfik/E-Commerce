using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.AdminRepositeries
{
    public interface IAdmin<TAdmin>
    {
        IList<TAdmin> list();
        TAdmin Find(int ID);
        void ADD(TAdmin admin);
        void Update(int ID, TAdmin admin);
        void Delete(int ID);
    }
}
