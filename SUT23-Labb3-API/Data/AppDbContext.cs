using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestPersonLink> InterestPersonLinks { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations
            modelBuilder.Entity<InterestPersonLink>()
                .HasKey(ipl => new { ipl.InterestId, ipl.PersonId, ipl.LinkId });

            modelBuilder.Entity<InterestPersonLink>()
                .HasOne(x => x.Persons)
                .WithMany(x => x.InterestPersonLinks)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<InterestPersonLink>()
                .HasOne(x => x.Interests)
                .WithMany(x => x.InterestPersonLinks)
                .HasForeignKey(x => x.InterestId);

            modelBuilder.Entity<InterestPersonLink>()
                .HasOne(x => x.Links)
                .WithMany(x => x.InterestPersonLinks)
                .HasForeignKey(x => x.LinkId)
                .IsRequired(false);



            // Testdata
            modelBuilder.Entity<Interest>().HasData(new Interest{
                InterestId = 1,
                InterestName = "Programmering",
                InterestDescription = "Programming in C#"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 2,
                InterestName = "Golf",
                InterestDescription = "Playing golf"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 3,
                InterestName = "Computers",
                InterestDescription = "How they work"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 4,
                InterestName = "Gaming",
                InterestDescription = "World of Warcraft"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 5,
                InterestName = "Music",
                InterestDescription = "Playing instrument"
            });


            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 1,
                LinkName = "https://sv.wikipedia.org/wiki/Programmering"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 2,
                LinkName = "https://sv.wikipedia.org/wiki/C"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 3,
                LinkName = "https://sv.wikipedia.org/wiki/Golf"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 4,
                LinkName = "https://sv.wikipedia.org/wiki/Tiger_Woods"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 5,
                LinkName = "https://sv.wikipedia.org/wiki/Musik"
            });


            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                PersonName = "Peter",
                PhoneNr = "1234567890"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                PersonName = "Johan",
                PhoneNr = "6758493201"
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                PersonName = "Sara",
                PhoneNr = "0987654321"
            });


            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 2,
                InterestId = 1,
                LinkId = 1
            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 2,
                InterestId = 1,
                LinkId = 2
            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 3,
                InterestId = 3,
                LinkId = 3
            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 1,
                InterestId = 2,
                LinkId = 3
            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 1,
                InterestId = 2,
                LinkId = 4
            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 3,
                InterestId = 4,
                LinkId = 3

            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 3,
                InterestId = 1,
                LinkId = 3

            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 1,
                InterestId = 4,
                LinkId = 3

            });
            modelBuilder.Entity<InterestPersonLink>().HasData(new InterestPersonLink
            {
                PersonId = 2,
                InterestId = 5,
                LinkId = 5
            });

        }
    }
}
