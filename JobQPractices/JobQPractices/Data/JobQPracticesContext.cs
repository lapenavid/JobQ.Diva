using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobQPractices.Models;

namespace JobQPractices.Data
{
    public class JobQPracticesContext : DbContext
    {
        public JobQPracticesContext(DbContextOptions<JobQPracticesContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<jobDetails>().HasData(GetJobDetails());
        }
        public DbSet<JobQPractices.Models.jobDetails> jobDetails { get; set; } = default!;


        private jobDetails[] GetJobDetails() => new jobDetails[] {
            new jobDetails
            {
                
                Description = "first job",
                JobStatus = JobStatus.New,
                FinishDate = DateTime.Now
            },
            new jobDetails
            {
               
                Description = "second job",
                JobStatus = JobStatus.Queued,
                FinishDate = DateTime.Now
            },
        };
    }
};

