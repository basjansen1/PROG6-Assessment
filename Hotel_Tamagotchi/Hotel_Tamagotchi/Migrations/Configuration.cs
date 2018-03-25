namespace Hotel_Tamagotchi.Migrations
{
    using Hotel_Tamagotchi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hotel_Tamagotchi.Models.Hotel_TamagotchiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Hotel_Tamagotchi.Models.Hotel_TamagotchiContext";
        }

        protected override void Seed(Hotel_Tamagotchi.Models.Hotel_TamagotchiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Rooms.AddOrUpdate(r => r.ID, new Room { ID = 1, Size = 2, Type = RoomType.Chillroom.ToString()});
            context.Rooms.AddOrUpdate(r => r.ID, new Room { ID = 2, Size = 3, Type = RoomType.Fightroom.ToString() });
            context.Rooms.AddOrUpdate(r => r.ID, new Room { ID = 3, Size = 5, Type = RoomType.Gameroom.ToString() });
            context.Rooms.AddOrUpdate(r => r.ID, new Room { ID = 4, Size = 5, Type = RoomType.Workroom.ToString() });

        }
    }
}
