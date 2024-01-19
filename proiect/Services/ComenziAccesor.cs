using Repository_DBFirst;
//using Repository_CodeFirst;
using System.Data.Entity;


namespace Accesor
{
    public class ComenziAccesor : BaseAccesor<comenzi>
    {
        public ComenziAccesor(DbContext context) : base(context)
        {
        }
    }
}