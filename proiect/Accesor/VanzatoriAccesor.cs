using Repository_DBFirst;
//using Repository_CodeFirst;
using System.Data.Entity;

namespace Accesor
{
    public class VanzatoriAccesor : BaseAccesor<vanzatori>
    {
        public VanzatoriAccesor(DbContext context) : base(context)
        {
        }
    }
}
