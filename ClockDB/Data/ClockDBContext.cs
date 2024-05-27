    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ClockDB.Models;

    namespace ClockDB.Data
    {
        public class ClockDBContext : DbContext
        {
            public ClockDBContext (DbContextOptions<ClockDBContext> options)
                : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("ClockDBContext");
                }
            }

            public DbSet<ClockDB.Models.UserTable> UserTable { get; set; } = default!;
            public DbSet<ClockDB.Models.UserProject> UserProject { get; set; } = default!;
            public DbSet<ClockDB.Models.TimeLogs> TimeLogs { get; set; } = default!;
            public DbSet<ClockDB.Models.Role> Role { get; set; } = default!;
            public DbSet<ClockDB.Models.Project> Project { get; set; } = default!;
    }
    }
