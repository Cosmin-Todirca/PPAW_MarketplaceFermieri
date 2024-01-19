using Repository_DBFirst;
//using Repository_CodeFirst;
using System.Data.Entity;


namespace Accesor
{
    public class ClientiAccesor : BaseAccesor<clienti>
    {
        public ClientiAccesor(DbContext context) : base(context)
        {
        }
    }
}
