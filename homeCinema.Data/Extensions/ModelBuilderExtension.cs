using homeCinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace homeCinema.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder builder)
        {
            // user: admin, password: homecinema
            builder.Entity<User>().HasData(new User 
            {
                Id = 1,
                Email = "prohotvulcan@gmail.com",
                UserName = "admin",
                HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                IsLocked = false,
                DateCreated = DateTime.Now
            });

            // add role admin
            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "admin",
            });

            // assign user to role
            builder.Entity<UserRole>().HasData(new UserRole
            {
                Id = 1,
                RoleId = 1,
                UserId = 1
            });

            // create genres
            builder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Comedy" },
                new Genre { Id = 4, Name = "Crime" },
                new Genre { Id = 5, Name = "Drama" },
                new Genre { Id = 6, Name = "Fantasy" },
                new Genre { Id = 7, Name = "Historical" },
                new Genre { Id = 8, Name = "Historical fiction" },
                new Genre { Id = 9, Name = "Horror" },
                new Genre { Id = 10, Name = "Magical realism" },
                new Genre { Id = 11, Name = "Mystery" },
                new Genre { Id = 12, Name = "Paranoid fiction" },
                new Genre { Id = 13, Name = "Philosophical" },
                new Genre { Id = 14, Name = "Political" },
                new Genre { Id = 15, Name = "Romance" },
                new Genre { Id = 16, Name = "Saga" },
                new Genre { Id = 17, Name = "Satire" },
                new Genre { Id = 18, Name = "Science fiction" },
                new Genre { Id = 19, Name = "Social" },
                new Genre { Id = 20, Name = "Speculative" },
                new Genre { Id = 21, Name = "Thriller" },
                new Genre { Id = 22, Name = "Urban" },
                new Genre { Id = 23, Name = "Western" });

            // create movies
            builder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Minions",
                    Image = "minions.jpg",
                    GenreId = 3,
                    Director = "Kyle Bald",
                    Writer = "Brian Lynch",
                    Producer = "Janet Healy",
                    ReleaseDate = new DateTime(2015, 7, 10),
                    Rating = 3,
                    Description = "Minions Stuart, Kevin and Bob are recruited by Scarlet Overkill, a super-villain who, alongside her inventor husband Herb, hatches a plot to take over the world.",
                    TrailerURI = "https://www.youtube.com/watch?v=Wfql_DoHRKc"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Ted 2",
                    Image = "ted2.jpg",
                    GenreId = 3,
                    Director = "Seth MacFarlane",
                    Writer = "Seth MacFarlane",
                    Producer = "Jason Clark",
                    ReleaseDate = new DateTime(2015, 6, 27),
                    Rating = 4,
                    Description = "Newlywed couple Ted and Tami-Lynn want to have a baby, but in order to qualify to be a parent, Ted will have to prove he's a person in a court of law.",
                    TrailerURI = "https://www.youtube.com/watch?v=S3AVcCggRnU"
                },
                new Movie
                {
                    Id = 3,
                    Title = "Trainwreck",
                    Image = "trainwreck.jpg",
                    GenreId = 18,
                    Director = "Judd Apatow",
                    Writer = "Amy Schumer",
                    Producer = "Judd Apatow",
                    ReleaseDate = new DateTime(2015, 7, 17),
                    Rating = 5,
                    Description = "Having thought that monogamy was never possible, a commitment-phobic career woman may have to face her fears when she meets a good guy.",
                    TrailerURI = "https://www.youtube.com/watch?v=2MxnhBPoIx4"
                },
                new Movie
                {
                    Id = 4,
                    Title = "Inside Out",
                    Image = "insideout.jpg",
                    GenreId = 3,
                    Director = "Pete Docter",
                    Writer = "Pete Docter",
                    Producer = "John Lasseter",
                    ReleaseDate = new DateTime(2015, 6, 19),
                    Rating = 4,
                    Description = "After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school.",
                    TrailerURI = "https://www.youtube.com/watch?v=seMwpP0yeu4"
                },
                new Movie
                {
                    Id = 5,
                    Title = "Home",
                    Image = "home.jpg",
                    GenreId = 3,
                    Director = "Tim Johnson",
                    Writer = "Tom J. Astle",
                    Producer = "Suzanne Buirgy",
                    ReleaseDate = new DateTime(2015, 5, 27),
                    Rating = 4,
                    Description = "Oh, an alien on the run from his own people, lands on Earth and makes friends with the adventurous Tip, who is on a quest of her own.",
                    TrailerURI = "https://www.youtube.com/watch?v=MyqZf8LiWvM"
                },
                new Movie
                {
                    Id = 6,
                    Title = "Batman v Superman: Dawn of Justice",
                    Image = "batmanvssuperman.jpg",
                    GenreId = 18,
                    Director = "Zack Snyder",
                    Writer = "Chris Terrio",
                    Producer = "Wesley Coller",
                    ReleaseDate = new DateTime(2015, 3, 25),
                    Rating = 4,
                    Description = "Fearing the actions of a god-like Super Hero left unchecked, Gotham City's own formidable, forceful vigilante takes on Metropolis most revered, modern-day savior, while the world wrestles with what sort of hero it really needs. And with Batman and Superman at war with one another, a new threat quickly arises, putting mankind in greater danger than it's ever known before.",
                    TrailerURI = "https://www.youtube.com/watch?v=0WWzgGyAH6Y"
                },
                new Movie
                {
                    Id = 7,
                    Title = "Ant-Man",
                    Image = "antman.jpg",
                    GenreId = 18,
                    Director = "Payton Reed",
                    Writer = "Edgar Wright",
                    Producer = "Victoria Alonso",
                    ReleaseDate = new DateTime(2015, 7, 17),
                    Rating = 5,
                    Description = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.",
                    TrailerURI = "https://www.youtube.com/watch?v=1HpZevFifuo"
                },
                new Movie
                {
                    Id = 8,
                    Title = "Jurassic World",
                    Image = "jurassicworld.jpg",
                    GenreId = 18,
                    Director = "Colin Trevorrow",
                    Writer = "Rick Jaffa",
                    Producer = "Patrick Crowley",
                    ReleaseDate = new DateTime(2015, 6, 12),
                    Rating = 4,
                    Description = "A new theme park is built on the original site of Jurassic Park. Everything is going well until the park's newest attraction--a genetically modified giant stealth killing machine--escapes containment and goes on a killing spree.",
                    TrailerURI = "https://www.youtube.com/watch?v=RFinNxS5KN4"
                },
                new Movie
                {
                    Id = 9,
                    Title = "Fantastic Four",
                    Image = "fantasticfour.jpg",
                    GenreId = 18,
                    Director = "Josh Trank",
                    Writer = "Simon Kinberg",
                    Producer = "Avi Arad",
                    ReleaseDate = new DateTime(2015, 8, 7),
                    Rating = 2,
                    Description = "Four young outsiders teleport to an alternate and dangerous universe which alters their physical form in shocking ways. The four must learn to harness their new abilities and work together to save Earth from a former friend turned enemy.",
                    TrailerURI = "https://www.youtube.com/watch?v=AAgnQdiZFsQ"
                },
                new Movie
                {
                    Id = 10,
                    Title = "Mad Max: Fury Road",
                    Image = "madmax.jpg",
                    GenreId = 18,
                    Director = "George Miller",
                    Writer = "George Miller",
                    Producer = "Bruce Berman",
                    ReleaseDate = new DateTime(2015, 5, 15),
                    Rating = 3,
                    Description = "In a stark desert landscape where humanity is broken, two rebels just might be able to restore order: Max, a man of action and of few words, and Furiosa, a woman of action who is looking to make it back to her childhood homeland.",
                    TrailerURI = "https://www.youtube.com/watch?v=hEJnMQG9ev8"
                },
                new Movie
                {
                    Id = 11,
                    Title = "True Detective",
                    Image = "truedetective.jpg",
                    GenreId = 3,
                    Director = "Nic Pizzolatto",
                    Writer = "Bill Bannerman",
                    Producer = "Richard Brown",
                    ReleaseDate = new DateTime(2015, 5, 15),
                    Rating = 4,
                    Description = "An anthology series in which police investigations unearth the personal and professional secrets of those involved, both within and outside the law.",
                    TrailerURI = "https://www.youtube.com/watch?v=TXwCoNwBSkQ"
                },
                new Movie
                {
                    Id = 12,
                    Title = "The Longest Ride",
                    Image = "thelongestride.jpg",
                    GenreId = 15,
                    Director = "Nic Pizzolatto",
                    Writer = "George Tillman Jr.",
                    Producer = "Marty Bowen",
                    ReleaseDate = new DateTime(2015, 5, 15),
                    Rating = 5,
                    Description = "After an automobile crash, the lives of a young couple intertwine with a much older man, as he reflects back on a past love.",
                    TrailerURI = "https://www.youtube.com/watch?v=FUS_Q7FsfqU"
                },
                new Movie
                {
                    Id = 13,
                    Title = "The Walking Dead",
                    Image = "thewalkingdead.jpg",
                    GenreId = 19,
                    Director = "Frank Darabont",
                    Writer = "David Alpert",
                    Producer = "Gale Anne Hurd",
                    ReleaseDate = new DateTime(2015, 3, 28),
                    Rating = 5,
                    Description = "Sheriff's Deputy Rick Grimes leads a group of survivors in a world overrun by zombies.",
                    TrailerURI = "https://www.youtube.com/watch?v=R1v0uFms68U"
                },
                new Movie
                {
                    Id = 14,
                    Title = "Southpaw",
                    Image = "southpaw.jpg",
                    GenreId = 1,
                    Director = "Antoine Fuqua",
                    Writer = "Kurt Sutter",
                    Producer = "Todd Black",
                    ReleaseDate = new DateTime(2015, 8, 17),
                    Rating = 4,
                    Description = "Boxer Billy Hope turns to trainer Tick Willis to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.",
                    TrailerURI = "https://www.youtube.com/watch?v=Mh2ebPxhoLs"
                },
                new Movie
                {
                    Id = 15,
                    Title = "Specter",
                    Image = "spectre.jpg",
                    GenreId = 1,
                    Director = "Sam Mendes",
                    Writer = "Ian Fleming",
                    Producer = "Zakaria Alaoui",
                    ReleaseDate = new DateTime(2015, 11, 5),
                    Rating = 5,
                    Description = "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.",
                    TrailerURI = "https://www.youtube.com/watch?v=LTDaET-JweU"
                });

            // create stocks
            List<Stock> stocks = new List<Stock>();
            int stockId = 0;
            for (int i = 1; i <= 15; i++)
            {
                // Three stocks for each movie
                for (int j = 0; j < 3; j++)
                {
                    stockId++;
                    Stock stock = new Stock()
                    {
                        Id = stockId,
                        MovieId = i,
                        UniqueKey = Guid.NewGuid(),
                        IsAvailable = true
                    };
                    stocks.Add(stock);
                }
            }

            builder.Entity<Stock>().HasData(stocks);
        }
    }
}
