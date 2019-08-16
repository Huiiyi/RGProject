using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace RGProject.Models
{
    public class RGProjectDbContext : DbContext
    {
        private IConfiguration Configuration;
        private RGProjectDbContext(IConfiguration configuration)
        {
            this.Configuration=configuration;
        }

    }
}