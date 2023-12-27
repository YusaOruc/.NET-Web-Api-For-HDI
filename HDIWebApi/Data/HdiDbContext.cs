using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HDIWebApi.Data
{
    public class HdiDbContext : IdentityDbContext
    {
        public HdiDbContext(DbContextOptions<HdiDbContext> options) : base(options)
        {
        }

    }
}
