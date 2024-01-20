using Repository_DBFirst;
//using Repository_CodeFirst;
using System.Data.Entity;

namespace Accesor
{
    public class ObiecteComandaAccesor : BaseAccesor<obiecteComanda>
    {
        public ObiecteComandaAccesor(DbContext context) : base(context)
        {
        }
    }
}