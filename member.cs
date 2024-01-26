using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendaftaran_anggota
{
    // Member.cs
    public class Member
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        // Tambahkan properti lain sesuai kebutuhan
    }

    // ApplicationContext.cs
    public class ApplicationContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("YOUR_POSTGRESQL_CONNECTION_STRING");
        }
    }

}
