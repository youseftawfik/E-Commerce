using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models.AdminRepositeries
{
    public class ProductDetailsRepo : IAdmin<ProdectDetails>
    {
        private readonly AppDBContext context;
        public ProductDetailsRepo(AppDBContext appDB)
        {
            context = appDB;
        }
        public void ADD(ProdectDetails admin)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public ProdectDetails Find(int ID)
        {
            throw new NotImplementedException();
        }

        public IList<ProdectDetails> list()
        {
            throw new NotImplementedException();
        }

        public void Update(int ID, ProdectDetails admin)
        {
            throw new NotImplementedException();
        }
    }
}
