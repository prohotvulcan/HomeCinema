using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace homeCinema.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IdentityCard = table.Column<string>(nullable: true),
                    UniqueKey = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Errors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<byte>(nullable: false),
                    TrailerURI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    UniqueKey = table.Column<Guid>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    StockId = table.Column<int>(nullable: false),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    ReturnedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 23, "Western" },
                    { 22, "Urban" },
                    { 21, "Thriller" },
                    { 20, "Speculative" },
                    { 19, "Social" },
                    { 18, "Science fiction" },
                    { 17, "Satire" },
                    { 16, "Saga" },
                    { 15, "Romance" },
                    { 14, "Political" },
                    { 13, "Philosophical" },
                    { 11, "Mystery" },
                    { 10, "Magical realism" },
                    { 9, "Horror" },
                    { 8, "Historical fiction" },
                    { 7, "Historical" },
                    { 6, "Fantasy" },
                    { 5, "Drama" },
                    { 4, "Crime" },
                    { 3, "Comedy" },
                    { 2, "Adventure" },
                    { 12, "Paranoid fiction" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "HashedPassword", "IsLocked", "Salt", "UserName" },
                values: new object[] { 1, new DateTime(2020, 4, 22, 16, 12, 19, 768, DateTimeKind.Local).AddTicks(5307), "prohotvulcan@gmail.com", "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=", false, "mNKLRbEFCH8y1xIyTXP4qA==", "admin" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "GenreId", "Image", "Producer", "Rating", "ReleaseDate", "Title", "TrailerURI", "Writer" },
                values: new object[,]
                {
                    { 14, "Boxer Billy Hope turns to trainer Tick Willis to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.", "Antoine Fuqua", 1, "southpaw.jpg", "Todd Black", (byte)4, new DateTime(2015, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Southpaw", "https://www.youtube.com/watch?v=Mh2ebPxhoLs", "Kurt Sutter" },
                    { 15, "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.", "Sam Mendes", 1, "spectre.jpg", "Zakaria Alaoui", (byte)5, new DateTime(2015, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Specter", "https://www.youtube.com/watch?v=LTDaET-JweU", "Ian Fleming" },
                    { 1, "Minions Stuart, Kevin and Bob are recruited by Scarlet Overkill, a super-villain who, alongside her inventor husband Herb, hatches a plot to take over the world.", "Kyle Bald", 3, "minions.jpg", "Janet Healy", (byte)3, new DateTime(2015, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minions", "https://www.youtube.com/watch?v=Wfql_DoHRKc", "Brian Lynch" },
                    { 2, "Newlywed couple Ted and Tami-Lynn want to have a baby, but in order to qualify to be a parent, Ted will have to prove he's a person in a court of law.", "Seth MacFarlane", 3, "ted2.jpg", "Jason Clark", (byte)4, new DateTime(2015, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ted 2", "https://www.youtube.com/watch?v=S3AVcCggRnU", "Seth MacFarlane" },
                    { 4, "After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school.", "Pete Docter", 3, "insideout.jpg", "John Lasseter", (byte)4, new DateTime(2015, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inside Out", "https://www.youtube.com/watch?v=seMwpP0yeu4", "Pete Docter" },
                    { 5, "Oh, an alien on the run from his own people, lands on Earth and makes friends with the adventurous Tip, who is on a quest of her own.", "Tim Johnson", 3, "home.jpg", "Suzanne Buirgy", (byte)4, new DateTime(2015, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Home", "https://www.youtube.com/watch?v=MyqZf8LiWvM", "Tom J. Astle" },
                    { 11, "An anthology series in which police investigations unearth the personal and professional secrets of those involved, both within and outside the law.", "Nic Pizzolatto", 3, "truedetective.jpg", "Richard Brown", (byte)4, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "True Detective", "https://www.youtube.com/watch?v=TXwCoNwBSkQ", "Bill Bannerman" },
                    { 12, "After an automobile crash, the lives of a young couple intertwine with a much older man, as he reflects back on a past love.", "Nic Pizzolatto", 15, "thelongestride.jpg", "Marty Bowen", (byte)5, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Longest Ride", "https://www.youtube.com/watch?v=FUS_Q7FsfqU", "George Tillman Jr." },
                    { 3, "Having thought that monogamy was never possible, a commitment-phobic career woman may have to face her fears when she meets a good guy.", "Judd Apatow", 18, "trainwreck.jpg", "Judd Apatow", (byte)5, new DateTime(2015, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trainwreck", "https://www.youtube.com/watch?v=2MxnhBPoIx4", "Amy Schumer" },
                    { 6, "Fearing the actions of a god-like Super Hero left unchecked, Gotham City's own formidable, forceful vigilante takes on Metropolis most revered, modern-day savior, while the world wrestles with what sort of hero it really needs. And with Batman and Superman at war with one another, a new threat quickly arises, putting mankind in greater danger than it's ever known before.", "Zack Snyder", 18, "batmanvssuperman.jpg", "Wesley Coller", (byte)4, new DateTime(2015, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman v Superman: Dawn of Justice", "https://www.youtube.com/watch?v=0WWzgGyAH6Y", "Chris Terrio" },
                    { 7, "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.", "Payton Reed", 18, "antman.jpg", "Victoria Alonso", (byte)5, new DateTime(2015, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ant-Man", "https://www.youtube.com/watch?v=1HpZevFifuo", "Edgar Wright" },
                    { 8, "A new theme park is built on the original site of Jurassic Park. Everything is going well until the park's newest attraction--a genetically modified giant stealth killing machine--escapes containment and goes on a killing spree.", "Colin Trevorrow", 18, "jurassicworld.jpg", "Patrick Crowley", (byte)4, new DateTime(2015, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jurassic World", "https://www.youtube.com/watch?v=RFinNxS5KN4", "Rick Jaffa" },
                    { 9, "Four young outsiders teleport to an alternate and dangerous universe which alters their physical form in shocking ways. The four must learn to harness their new abilities and work together to save Earth from a former friend turned enemy.", "Josh Trank", 18, "fantasticfour.jpg", "Avi Arad", (byte)2, new DateTime(2015, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantastic Four", "https://www.youtube.com/watch?v=AAgnQdiZFsQ", "Simon Kinberg" },
                    { 10, "In a stark desert landscape where humanity is broken, two rebels just might be able to restore order: Max, a man of action and of few words, and Furiosa, a woman of action who is looking to make it back to her childhood homeland.", "George Miller", 18, "madmax.jpg", "Bruce Berman", (byte)3, new DateTime(2015, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mad Max: Fury Road", "https://www.youtube.com/watch?v=hEJnMQG9ev8", "George Miller" },
                    { 13, "Sheriff's Deputy Rick Grimes leads a group of survivors in a world overrun by zombies.", "Frank Darabont", 19, "thewalkingdead.jpg", "Gale Anne Hurd", (byte)5, new DateTime(2015, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Walking Dead", "https://www.youtube.com/watch?v=R1v0uFms68U", "David Alpert" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "IsAvailable", "MovieId", "UniqueKey" },
                values: new object[,]
                {
                    { 40, true, 14, new Guid("866f6974-68fb-4cd5-9513-f46ee7018a88") },
                    { 7, true, 3, new Guid("b82dfa6f-5fec-4aa9-a104-c269398426ac") },
                    { 8, true, 3, new Guid("447fef8c-fef9-4ca9-aaed-00ad5bbddc35") },
                    { 9, true, 3, new Guid("4f1db240-31ff-4a5d-b429-f6f7b92859a7") },
                    { 16, true, 6, new Guid("ea354c43-ae49-4c9b-a6ac-78efe0abbb1a") },
                    { 17, true, 6, new Guid("916d2891-018a-458b-822a-41c913fa59e8") },
                    { 18, true, 6, new Guid("af15b6d9-b23d-4ed2-9c5b-58705cc6d71e") },
                    { 19, true, 7, new Guid("db38f990-2b6a-4463-8de1-80566f7e7758") },
                    { 20, true, 7, new Guid("5e55a11e-e79d-46e8-9a02-7530df6b3cf2") },
                    { 21, true, 7, new Guid("e75b9f86-fa08-4d06-bb1d-0b84d6be2f94") },
                    { 22, true, 8, new Guid("6a38b176-13f5-48fe-be1e-3e60145b0da2") },
                    { 23, true, 8, new Guid("7a0070ff-5be6-4e22-b48e-f2b158d025e4") },
                    { 24, true, 8, new Guid("64948142-b619-4834-80a6-2c92dea6554c") },
                    { 25, true, 9, new Guid("f3762f92-e348-4ee2-94d1-58219b9fdb76") },
                    { 26, true, 9, new Guid("681ba4cb-634a-49ae-b269-4bb17f20c0b3") },
                    { 27, true, 9, new Guid("e9dd7a37-0aa9-4d7a-8723-9a906d2b83cb") },
                    { 28, true, 10, new Guid("9b52487d-3604-4af6-a758-34a16e2fc92a") },
                    { 29, true, 10, new Guid("75fda971-9ab6-48d7-bb7d-e8f6768c3206") },
                    { 30, true, 10, new Guid("8a0c04e2-5a9b-484f-b346-e4ec2837e4bb") },
                    { 37, true, 13, new Guid("81fd640c-f3ac-47c8-ba53-9280a89c372f") },
                    { 36, true, 12, new Guid("aac7d412-d02f-40f1-9fa6-57bd0fdb4c16") },
                    { 38, true, 13, new Guid("bf73cce5-5d97-4e8b-9e37-998efd142780") },
                    { 35, true, 12, new Guid("06059a91-bee9-4943-8b0e-c82088423477") },
                    { 33, true, 11, new Guid("16e5a245-e4ef-469f-8f48-9efec75099cf") },
                    { 41, true, 14, new Guid("d31846f5-6a10-46ab-b4b2-d814199877e7") },
                    { 42, true, 14, new Guid("3c3406a7-90e5-46cf-b141-f1cb0be3e00c") },
                    { 43, true, 15, new Guid("7aa618a5-3e49-4f1c-85af-0cf572a62c81") },
                    { 44, true, 15, new Guid("e45b8347-7ef0-4d66-979c-fbb818dd440c") },
                    { 45, true, 15, new Guid("a9e8ecb3-5e15-45f3-bea9-55ae07e4a9f7") },
                    { 1, true, 1, new Guid("527a258c-f8aa-4372-8b5b-f418f6a0da87") },
                    { 2, true, 1, new Guid("680955fb-7e5d-4fe0-aa85-ffd760160e1a") },
                    { 3, true, 1, new Guid("77f1a594-fe76-4614-b234-0b2b405eee86") },
                    { 4, true, 2, new Guid("fa71a826-3a85-4a4b-b271-f64db32390b8") },
                    { 5, true, 2, new Guid("50fb6efd-ad83-4061-847e-92a05fe1a965") },
                    { 6, true, 2, new Guid("d80507db-d514-4f74-912d-c10b23bb3a03") },
                    { 10, true, 4, new Guid("3f9a0488-48e4-4065-a354-5e3b599e8b4a") },
                    { 11, true, 4, new Guid("106be3af-b434-4556-8ae0-b716fd90b255") },
                    { 12, true, 4, new Guid("76aa4ccb-c335-426d-b005-cbe90ee114a7") },
                    { 13, true, 5, new Guid("24f79bb4-7e18-4273-b511-35a2ee8b58fa") },
                    { 14, true, 5, new Guid("417dfbd4-5946-4f6d-987f-912ff7bd3446") },
                    { 15, true, 5, new Guid("79d2622c-e01e-4f7d-90c9-8df7be9d6860") },
                    { 31, true, 11, new Guid("2c66ac82-a88e-4796-869d-9650adcf8c5e") },
                    { 32, true, 11, new Guid("a8ad7930-0787-404e-b725-4d56e7a80e0d") },
                    { 34, true, 12, new Guid("f7533c80-460e-443e-82d2-7e36307014a2") },
                    { 39, true, 13, new Guid("56f73f03-d933-4bba-b15b-20077838b8c8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_StockId",
                table: "Rentals",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MovieId",
                table: "Stocks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errors");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
