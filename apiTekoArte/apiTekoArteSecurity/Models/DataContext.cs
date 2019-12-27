namespace apiTekoArteSecurity.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiTekoArteSecurity.Models.TekoArte> TekoArtes { get; set; }
    }
}