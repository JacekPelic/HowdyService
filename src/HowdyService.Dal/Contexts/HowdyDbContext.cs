using HowdyService.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HowdyService.Dal.Contexts
{
    public class HowdyDbContext : DbContext
    {
        public HowdyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Anwser> Anwsers { get; set; }
        public DbSet<Gif> Gifs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "Do you feel groovy?",
                },
                new Question
                {
                    Id = 2,
                    Text = "How's it hanging?",
                },
                new Question
                {
                    Id = 3,
                    Text = "Are you Jivin' yet?"
                },
                new Question
                {
                    Id = 4,
                    Text = "How Well Jacek did on this challange?"
                }
                );

            modelBuilder.Entity<Anwser>().HasData
                (
                    new Anwser { Id = 1, QuestionId = 1, Text = "Dream On", Value = 1 },
                    new Anwser { Id = 2, QuestionId = 1, Text = "You Know", Value = 2 },
                    new Anwser { Id = 3, QuestionId = 1, Text = "Off the hook", Value = 3 },
                    new Anwser { Id = 4, QuestionId = 1, Text = "Hell yeah", Value = 4 },

                    new Anwser { Id = 5, QuestionId = 2, Text = "What it is, what it is", Value = 1 },
                    new Anwser { Id = 6, QuestionId = 2, Text = "Ace", Value = 2 },
                    new Anwser { Id = 7, QuestionId = 2, Text = "Primo", Value = 3 },
                    new Anwser { Id = 8, QuestionId = 2, Text = "Secundo", Value = 4 },

                    new Anwser { Id = 9, QuestionId = 3, Text = "Buzz Off", Value = 1 },
                    new Anwser { Id = 10, QuestionId = 3, Text = "Bitch'n", Value = 2 },
                    new Anwser { Id = 11, QuestionId = 3, Text = "Bangin", Value = 3 },
                    new Anwser { Id = 12, QuestionId = 3, Text = "Laaame", Value = 4 },

                    new Anwser { Id = 13, QuestionId = 4, Text = "Ok", Value = 1 },
                    new Anwser { Id = 14, QuestionId = 4, Text = "Pretty good", Value = 2 },
                    new Anwser { Id = 15, QuestionId = 4, Text = "Awsome", Value = 3 },
                    new Anwser { Id = 16, QuestionId = 4, Text = "And we have new student developer!", Value = 4 }
                );

            modelBuilder.Entity<Gif>().HasData
                (
                    new Gif { Id = 1, Name = "Css", GiphyId = "wh9Ftb014GmKQ" },
                    new Gif { Id = 2, Name = "JavaScript", GiphyId = "10bdAP4IOmoN7G" },
                    new Gif { Id = 3, Name = "JavaVsC++", GiphyId = "ip2GZs8rLxt8k" },
                    new Gif { Id = 4, Name = "Poker", GiphyId = "11CXAq0P8h50GI" }
                );
        }
    }
}
