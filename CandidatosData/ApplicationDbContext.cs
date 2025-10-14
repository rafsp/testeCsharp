using CandidatosModel;
using Microsoft.EntityFrameworkCore;

namespace CandidatosData
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CandidatoModel> Candidatos { get; set; }
    }
}