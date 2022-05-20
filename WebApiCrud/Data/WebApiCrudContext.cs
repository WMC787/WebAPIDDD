using Microsoft.EntityFrameworkCore;
using WebApiCrud.Entities;

namespace WebApiCrud.Data
{
    public class WebApiCrudContext: DbContext
    {
        public WebApiCrudContext(DbContextOptions<WebApiCrudContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }    

    }
}
