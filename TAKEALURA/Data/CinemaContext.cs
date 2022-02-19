using Microsoft.EntityFrameworkCore;
using TAKEALURA.Models;

namespace TAKEALURA.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> opts) : base(opts)
        {
            
        }
        
        
    }
} 