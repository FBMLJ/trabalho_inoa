using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMoeda.Models;
using MvcMonitoramento.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMoeda.Models.Moeda> Moeda { get; set; } = default!;

        public DbSet<MvcMonitoramento.Models.Monitoramento> Monitoramento { get; set; } = default!;
    }
