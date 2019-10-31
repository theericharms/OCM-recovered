using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;
using WebMatrix.WebData;

namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OCMovers_MVC4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OCMovers_MVC4Context context)
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("OCMovers_MVC4Context", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            
            //var roomList = new List<Room>
            //{
            //    new Room { RoomName = "Bedroom", Seed = 1 },
            //    new Room { RoomName = "Bathroom", Seed = 2 },
            //    new Room { RoomName = "Home Office", Seed = 3 },
            //    new Room { RoomName = "Living Room", Seed = 4 },
            //    new Room { RoomName = "Dining Room", Seed = 5 },
            //    new Room { RoomName = "Kitchen", Seed = 6 },
            //    new Room { RoomName = "Den / Family Room", Seed = 7 },
            //    new Room { RoomName = "Basement", Seed = 8 },
            //    new Room { RoomName = "Garage", Seed = 9 },
            //    new Room { RoomName = "Outdoor" , Seed = 10},
            //    new Room { RoomName = "Attic", Seed = 11 },
            //    new Room { RoomName = "Laundry Room", Seed = 12 },
            //    new Room { RoomName = "Storage Room / Storage Facility", Seed = 13 },
            //    new Room { RoomName = "Other", Seed = 14 }
            //};

            //foreach (Room t in roomList)
            //{
            //    var tInDb = context.Room.FirstOrDefault(s => s.Seed == t.Seed);

            //    if (tInDb == null)
            //    {
            //        context.Room.Add(t);
            //    }
            //}

            //context.SaveChanges();

            //var inventoryList = new List<InventoryItem>
            //{
            //    new InventoryItem { inventoryItem = "Sofa Small", Seed = 1 },
            //    new InventoryItem { inventoryItem = "Sofa Medium", Seed = 2 },
            //    new InventoryItem { inventoryItem = "Sofa Large", Seed = 3 },
            //    new InventoryItem { inventoryItem = "Coffee Table Small", Seed = 4 },
            //    new InventoryItem { inventoryItem = "Coffee Table Medium", Seed = 5 },
            //    new InventoryItem { inventoryItem = "Coffee Table Large", Seed = 6 },
            //    new InventoryItem { inventoryItem = "TV Stand Small", Seed = 7 },
            //    new InventoryItem { inventoryItem = "TV Stand Medium", Seed = 8 },
            //    new InventoryItem { inventoryItem = "TV Stand Large", Seed = 9 },
            //    new InventoryItem { inventoryItem = "Bookshelf Small", Seed = 10 },
            //    new InventoryItem { inventoryItem = "Bookshelf Medium", Seed = 11 },
            //    new InventoryItem { inventoryItem = "Bookshelf Large", Seed = 12 },
            //    new InventoryItem { inventoryItem = "Dining Table Small", Seed = 13 },
            //    new InventoryItem { inventoryItem = "Dining Table Medium", Seed = 14 },
            //    new InventoryItem { inventoryItem = "Dining Table Large", Seed = 15 },
            //    new InventoryItem { inventoryItem = "Laundry Dryer", Seed = 19 },
            //    new InventoryItem { inventoryItem = "Laundry Washer", Seed = 20 },
            //    new InventoryItem { inventoryItem = "Bed Queen", Seed = 21 },
            //    new InventoryItem { inventoryItem = "Bed King", Seed = 22 },
            //    new InventoryItem { inventoryItem = "Bed Twin" , Seed = 23},
            //    new InventoryItem { inventoryItem = "Bed Full" , Seed = 24},
            //    new InventoryItem { inventoryItem = "Box Spring" , Seed = 25},
            //    new InventoryItem { inventoryItem = "Night Stand / End Table" , Seed = 26},
            //    new InventoryItem { inventoryItem = "Armoire" , Seed = 27},
            //    new InventoryItem { inventoryItem = "Headboard" , Seed = 28},
            //    new InventoryItem { inventoryItem = "Footboard" , Seed = 29},
            //    new InventoryItem { inventoryItem = "Chair Small" , Seed = 30},
            //    new InventoryItem { inventoryItem = "Chair Medium" , Seed = 31},
            //    new InventoryItem { inventoryItem = "Chair Large" , Seed = 32},
            //    new InventoryItem { inventoryItem = "Dining Chair" , Seed = 33},
            //    new InventoryItem { inventoryItem = "TV Small" , Seed = 34},
            //    new InventoryItem { inventoryItem = "TV Medium" , Seed = 35},
            //    new InventoryItem { inventoryItem = "TV Large" , Seed = 36},
            //    new InventoryItem { inventoryItem = "Desk" , Seed = 37},
            //    new InventoryItem { inventoryItem = "Lamp Floor" , Seed = 38},
            //    new InventoryItem { inventoryItem = "Lamp Table" , Seed = 39},
            //    new InventoryItem { inventoryItem = "Buffet" , Seed = 40},
            //    new InventoryItem { inventoryItem = "China Cabinet Small" , Seed = 41},
            //    new InventoryItem { inventoryItem = "China Cabinet Large" , Seed = 42},
            //    new InventoryItem { inventoryItem = "Patio Table" , Seed = 43},
            //    new InventoryItem { inventoryItem = "Patio Table Chairs" , Seed = 44},
            //    new InventoryItem { inventoryItem = "Grill" , Seed = 45},
            //    new InventoryItem { inventoryItem = "Exercise Equipment" , Seed = 46},
            //    new InventoryItem { inventoryItem = "Plants Large" , Seed = 47},
            //    new InventoryItem { inventoryItem = "Artwork, Large & Framed" , Seed = 48},
            //};

            //foreach (InventoryItem t in inventoryList)
            //{
            //    var tInDb = context.InventoryItem.FirstOrDefault(s => s.Seed == t.Seed);

            //    if (tInDb == null)
            //    {
            //        context.InventoryItem.Add(t);
            //    }
            //}

            //context.SaveChanges();

            //var content = new List<Content>
            //{
            //    new Content { About="This is sample about text", Contact="This is sample contact text", FAQ="This is sample FAQ text", Services="This is sample Services text"}
            //};

            //content.ForEach(c => context.Content.Add(c));
            //context.SaveChanges();

            //var USStates = new List<USStates>
            //{
            //    new USStates { stateAbbr="DC", stateName = "District of Columbia"},
            //    new USStates { stateAbbr="AL", stateName = "Alabama"},
            //    new USStates { stateAbbr="AK", stateName = "Alaska"},
            //    new USStates { stateAbbr="AZ", stateName = "Arizona"},
            //    new USStates { stateAbbr="AR", stateName = "Arkansas"},
            //    new USStates { stateAbbr="CA", stateName = "California"},
            //    new USStates { stateAbbr="CO", stateName = "Colorado"},
            //    new USStates { stateAbbr="CT", stateName = "Connecticut"},
            //    new USStates { stateAbbr="DE", stateName = "Delaware"},
            //    new USStates { stateAbbr="FL", stateName = "Florida"},
            //    new USStates { stateAbbr="GA", stateName = "Georgia"},
            //    new USStates { stateAbbr="HI", stateName = "Hawaii"},
            //    new USStates { stateAbbr="ID", stateName = "Idaho"},
            //    new USStates { stateAbbr="IL", stateName = "Illinois"},
            //    new USStates { stateAbbr="IN", stateName = "Indiana"},
            //    new USStates { stateAbbr="IA", stateName = "Iowa"},
            //    new USStates { stateAbbr="KS", stateName = "Kansas"},
            //    new USStates { stateAbbr="KY", stateName = "Kentucky"},
            //    new USStates { stateAbbr="LA", stateName = "Louisiana"},
            //    new USStates { stateAbbr="ME", stateName = "Maine"},
            //    new USStates { stateAbbr="MD", stateName = "Maryland"},
            //    new USStates { stateAbbr="MA", stateName = "Massachusetts"},
            //    new USStates { stateAbbr="MI", stateName = "Michigan"},
            //    new USStates { stateAbbr="MN", stateName = "Minnesota"},
            //    new USStates { stateAbbr="MS", stateName = "Mississippi"},
            //    new USStates { stateAbbr="MO", stateName = "Missouri"},
            //    new USStates { stateAbbr="MT", stateName = "Montana"},
            //    new USStates { stateAbbr="NE", stateName = "Nebraska"},
            //    new USStates { stateAbbr="NV", stateName = "Nevada"},
            //    new USStates { stateAbbr="NH", stateName = "New Hampshire"},
            //    new USStates { stateAbbr="NJ", stateName = "New Jersey"},
            //    new USStates { stateAbbr="NM", stateName = "New Mexico"},
            //    new USStates { stateAbbr="NY", stateName = "New York"},
            //    new USStates { stateAbbr="NC", stateName = "North Carolina"},
            //    new USStates { stateAbbr="ND", stateName = "North Dakota"},
            //    new USStates { stateAbbr="OH", stateName = "Ohio"},
            //    new USStates { stateAbbr="OK", stateName = "Oklahoma"},
            //    new USStates { stateAbbr="OR", stateName = "Oregon"},
            //    new USStates { stateAbbr="PA", stateName = "Pennsylvania"},
            //    new USStates { stateAbbr="RI", stateName = "Rhode Island"},
            //    new USStates { stateAbbr="SC", stateName = "South Carolina"},
            //    new USStates { stateAbbr="SD", stateName = "South Dakota"},
            //    new USStates { stateAbbr="TN", stateName = "Tennessee"},
            //    new USStates { stateAbbr="TX", stateName = "Texas"},
            //    new USStates { stateAbbr="UT", stateName = "Utah"},
            //    new USStates { stateAbbr="VT", stateName = "Vermont"},
            //    new USStates { stateAbbr="VA", stateName = "Virginia"},
            //    new USStates { stateAbbr="WA", stateName = "Washington"},
            //    new USStates { stateAbbr="WV", stateName = "West Virginia"},
            //    new USStates { stateAbbr="WI", stateName = "Wisconsin"},
            //    new USStates { stateAbbr="WY", stateName = "Wyoming"}
            //};

            //var roles = (SimpleRoleProvider)Roles.Provider;
            ////var membership = (SimpleMembershipProvider)Membership.Provider;

            //if (!roles.RoleExists("Administrator"))
            //{
            //    roles.CreateRole("Administrator");
            //}

            //if (!roles.RoleExists("General"))
            //{
            //    roles.CreateRole("General");
            //}

            //if (!WebSecurity.UserExists("fmeenz"))
            //{
            //    WebSecurity.CreateUserAndAccount(
            //    "fmeenz",
            //    "loungeno4",
            //    new
            //    {
            //        EmailAddress = @ConfigurationManager.AppSettings["EricBCCEmail"],
            //        SoftDelete = false,
            //        Active = true,
            //        BFirstName = "eric",
            //        BLastName = "harms",
            //        BAddressLine1 = "450 sherwood drive",
            //        BAddressLine2 = "206",
            //        BCityProvince = "sausalito",
            //        BState = "ca",
            //        BPostal = "94965",
            //        BCountry = 225,
            //        BPhone = "2679804251"
            //    }, false);

            //    roles.AddUsersToRoles(new[] { "fmeenz" }, new[] { "Administrator" });
            //}
        }
    }
}
