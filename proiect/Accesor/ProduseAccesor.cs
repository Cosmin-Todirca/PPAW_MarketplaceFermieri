using Repository_DBFirst;
//using Repository_CodeFirst;
using System.Data.Entity;
using System.Linq;

namespace Accesor
{
    public class ProduseAccesor : BaseAccesor<produse>
    {
        public ProduseAccesor(DbContext context) : base(context)
        {
        }

        public produse GetProduseWithVanzatori(int idProduse)
        {
            return _dbContext.Set<produse>()
                .Include(p => p.vanzatori)
                .FirstOrDefault(p => p.idProdus == idProduse);
        }
    }
}