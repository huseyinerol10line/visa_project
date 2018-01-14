using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExploreCaliforniaa.Models
{
    public class BlogDataContext : DbContext
    {

        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewQuestion> QuestionAnswerr { get; set; }
        public DbSet<Visa> VisaTypes { get; set; }

        public BlogDataContext(DbContextOptions<BlogDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
