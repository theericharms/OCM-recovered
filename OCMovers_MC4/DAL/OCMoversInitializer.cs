using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MVC4.DAL
{
    public class OCMoversInitializer : DropCreateDatabaseIfModelChanges<OCMovers_MVC4Context>
    {
        protected override void Seed(OCMovers_MVC4Context mvc4Context)
        {
            //var roomList = new List<Room>
            //{
            //    new Room { RoomName = "Bedroom" },
            //    new Room { RoomName = "Bathroom" },
            //    new Room { RoomName = "Home Office" },
            //    new Room { RoomName = "Living Room" },
            //    new Room { RoomName = "Dining Room" },
            //    new Room { RoomName = "Kitchen" },
            //    new Room { RoomName = "Den / Family Room" },
            //    new Room { RoomName = "Basement" },
            //    new Room { RoomName = "Garage" },
            //    new Room { RoomName = "Outdoor" },
            //    new Room { RoomName = "Attic" },
            //    new Room { RoomName = "Laundry Room" },
            //    new Room { RoomName = "Storage Room / Storage Facility" },
            //    new Room { RoomName = "Other" }
            //};
            //roomList.ForEach(s => mvc4Context.Room.Add(s));
            //mvc4Context.SaveChanges();

            //var inventoryList = new List<InventoryItem>
            //{
            //    new InventoryItem { inventoryItem = "Sofa Small" },
            //    new InventoryItem { inventoryItem = "Sofa Medium" },
            //    new InventoryItem { inventoryItem = "Sofa Large" },
            //    new InventoryItem { inventoryItem = "Coffee Table Small" },
            //    new InventoryItem { inventoryItem = "Coffee Table Medium" },
            //    new InventoryItem { inventoryItem = "Coffee Table Large" },
            //    new InventoryItem { inventoryItem = "TV Stand Small" },
            //    new InventoryItem { inventoryItem = "TV Stand Medium" },
            //    new InventoryItem { inventoryItem = "TV Stand Large" },
            //    new InventoryItem { inventoryItem = "Floor Shelving Small" },
            //    new InventoryItem { inventoryItem = "Floor Shelving Medium" },
            //    new InventoryItem { inventoryItem = "Floor Shelving Large" },
            //    new InventoryItem { inventoryItem = "Dining Table Small" },
            //    new InventoryItem { inventoryItem = "Dining Table Medium" },
            //    new InventoryItem { inventoryItem = "Dining Table Large" },
            //    new InventoryItem { inventoryItem = "Bar Small" },
            //    new InventoryItem { inventoryItem = "Bar Medium" },
            //    new InventoryItem { inventoryItem = "Bar Large" },
            //    new InventoryItem { inventoryItem = "Laundry Dryer" },
            //    new InventoryItem { inventoryItem = "Laundry Washer" },
            //    new InventoryItem { inventoryItem = "Bed Queen" },
            //    new InventoryItem { inventoryItem = "Bed King" },
            //    new InventoryItem { inventoryItem = "Bed California King" },
            //};

            //inventoryList.ForEach(s => mvc4Context.InventoryItem.Add(s));
            //mvc4Context.SaveChanges();

            //var content = new List<Content>
            //{
            //    new Content { About="This is sample about text", Contact="This is sample contact text", FAQ="This is sample FAQ text", Services="This is sample Services text"}
            //};

            //content.ForEach(c => mvc4Context.Content.Add(c));
            //mvc4Context.SaveChanges();

        }
    }
}