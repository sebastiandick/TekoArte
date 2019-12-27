

namespace apiTekoArte.Models
{
    using System.Data.Entity;

    public class DataContext: DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiTekoArte.Models.TekoArte> TekoArtes { get; set; }
    }
}