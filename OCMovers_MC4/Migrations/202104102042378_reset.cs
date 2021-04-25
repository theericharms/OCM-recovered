namespace OCMovers_MC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Content",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            About = c.String(),
            //            Services = c.String(),
            //            Contact = c.String(),
            //            FAQ = c.String(),
            //            Thanks = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.CustomerAddress",
            //    c => new
            //        {
            //            AddressId = c.Int(nullable: false, identity: true),
            //            EstimateId = c.Int(nullable: false),
            //            AddressType = c.String(),
            //            BuildingName = c.String(),
            //            Address1 = c.String(),
            //            AptNum = c.String(),
            //            City = c.String(),
            //            State = c.String(),
            //            Postcode = c.String(),
            //            HouseOrApt = c.String(),
            //            HouseStories = c.String(),
            //            AptFloor = c.Int(nullable: false),
            //            ElevatorStairs = c.String(),
            //            ElevatorStairsDescription = c.String(),
            //            Stairs = c.Boolean(nullable: false),
            //            StairsDescription = c.String(),
            //            LongWalks = c.Boolean(nullable: false),
            //            LongWalksDescription = c.String(),
            //            NumberOfBedrooms = c.Int(nullable: false),
            //            Inventory = c.String(),
            //            SpecialCare = c.Boolean(nullable: false),
            //            SpecialCareDescription = c.String(),
            //            Notes = c.String(),
            //            StorageType = c.String(),
            //            StorageLongWalks = c.Boolean(nullable: false),
            //            StorageLongWalksDescription = c.String(),
            //            StorageGroundFloorElevator = c.String(),
            //            ApartemntMultipleLevels = c.Boolean(nullable: false),
            //            ApartmentMultipleLevelsDescription = c.String(),
            //            BoxCount = c.String(),
            //        })
            //    .PrimaryKey(t => t.AddressId);
            
            //CreateTable(
            //    "dbo.CustomerEstimates",
            //    c => new
            //        {
            //            CustomerEstimatesId = c.Int(nullable: false, identity: true),
            //            CreateDate = c.DateTime(nullable: false),
            //            EstimateId = c.Int(nullable: false),
            //            IntroText = c.String(),
            //            CustomerName = c.String(),
            //            PhoneNumber = c.String(),
            //            Start = c.String(),
            //            End = c.String(),
            //            MoveDate = c.DateTime(nullable: false),
            //            ArrivalTime = c.String(),
            //            ArrivalText = c.String(),
            //            HourlyRateText = c.String(),
            //            TravelTimeText = c.String(),
            //            Fuel = c.String(),
            //            Tolls = c.String(),
            //            ParkingPermits = c.String(),
            //            HoursEstimate = c.String(),
            //            TotalEstimate = c.String(),
            //            ReadPoliciesText = c.String(),
            //            ParkingPermitsText = c.String(),
            //            ResponsibleText = c.String(),
            //            ElevatorText = c.String(),
            //            MattressCoverText = c.String(),
            //            StormText = c.String(),
            //            CancellationText = c.String(),
            //            PaymentsText = c.String(),
            //            RepName = c.String(),
            //        })
            //    .PrimaryKey(t => t.CustomerEstimatesId);
            
            //CreateTable(
            //    "dbo.EstimateForm",
            //    c => new
            //        {
            //            EstimateFormID = c.Int(nullable: false, identity: true),
            //            submitDate = c.DateTime(nullable: false),
            //            moveDateEnd = c.DateTime(nullable: false),
            //            IsDateFlexible = c.Boolean(nullable: false),
            //            EstimateGuid = c.Guid(nullable: false),
            //            moveDescription = c.String(),
            //            dwellingTypeCurrent = c.String(),
            //            dwellingTypeCurrentFloorApt = c.String(),
            //            dwellingTypeCurrentFloorHouse = c.String(),
            //            dwellingTypeDestination = c.String(),
            //            dwellingTypeDestinationFloorApt = c.String(),
            //            dwellingTypeDestinationFloorHouse = c.String(),
            //            numRoomsCurrent = c.Int(nullable: false),
            //            numRoomsDestination = c.Int(nullable: false),
            //            loc1BuildingName = c.String(),
            //            loc1Address1 = c.String(),
            //            loc1Address2 = c.String(),
            //            loc1Apartment = c.String(),
            //            loc1City = c.String(),
            //            loc1State = c.String(),
            //            loc1Postal = c.String(),
            //            loc2BuildingName = c.String(),
            //            loc2Address1 = c.String(),
            //            loc2Address2 = c.String(),
            //            loc2Apartment = c.String(),
            //            loc2City = c.String(),
            //            loc2State = c.String(),
            //            loc2Postal = c.String(),
            //            elevStairsCurrent = c.String(),
            //            elevStairsDestination = c.String(),
            //            elevStairsRes = c.Boolean(nullable: false),
            //            elevStairsResExp = c.String(),
            //            stairsToFront = c.Boolean(nullable: false),
            //            stairsToFrontExp = c.String(),
            //            longWalksToDoor = c.Boolean(nullable: false),
            //            longWalksToDoorExp = c.String(),
            //            specialCareItem = c.Boolean(nullable: false),
            //            specialCareItemExp = c.String(),
            //            estBoxCount = c.String(),
            //            agreeCorrect = c.Boolean(nullable: false),
            //            InventoryWriteIn = c.String(),
            //            name = c.String(nullable: false),
            //            email = c.String(nullable: false),
            //            phone = c.String(nullable: false),
            //            PreviousCustomer = c.Boolean(nullable: false),
            //            PreviousCustomerName = c.String(),
            //            Feedback = c.String(),
            //            packingServices = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.EstimateFormID);
            
            //CreateTable(
            //    "dbo.InventoryItem",
            //    c => new
            //        {
            //            InventoryItemID = c.Int(nullable: false, identity: true),
            //            inventoryItem = c.String(nullable: false),
            //            Seed = c.Int(nullable: false),
            //            test = c.String(),
            //            Room_RoomID = c.Int(),
            //            EstimateForm_EstimateFormID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.InventoryItemID)
            //    .ForeignKey("dbo.Room", t => t.Room_RoomID)
            //    .ForeignKey("dbo.EstimateForm", t => t.EstimateForm_EstimateFormID)
            //    .Index(t => t.Room_RoomID)
            //    .Index(t => t.EstimateForm_EstimateFormID);
            
            //CreateTable(
            //    "dbo.Room",
            //    c => new
            //        {
            //            RoomID = c.Int(nullable: false, identity: true),
            //            RoomName = c.String(nullable: false),
            //            Seed = c.Int(nullable: false),
            //            EstimateForm_EstimateFormID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.RoomID)
            //    .ForeignKey("dbo.EstimateForm", t => t.EstimateForm_EstimateFormID)
            //    .Index(t => t.EstimateForm_EstimateFormID);
            
            //CreateTable(
            //    "dbo.EstimateFormInventory",
            //    c => new
            //        {
            //            efiID = c.Int(nullable: false, identity: true),
            //            efEstimateGuid = c.Guid(nullable: false),
            //            customOrId = c.String(),
            //            Qty = c.Int(nullable: false),
            //            efInvItemId = c.Int(),
            //            CustomItem = c.String(),
            //            efInvItem_InventoryItemID = c.Int(),
            //            efRoom_RoomID = c.Int(),
            //        })
            //    .PrimaryKey(t => t.efiID)
            //    .ForeignKey("dbo.InventoryItem", t => t.efInvItem_InventoryItemID)
            //    .ForeignKey("dbo.Room", t => t.efRoom_RoomID)
            //    .Index(t => t.efInvItem_InventoryItemID)
            //    .Index(t => t.efRoom_RoomID);
            
            //CreateTable(
            //    "dbo.webpages_Membership",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false),
            //            CreateDate = c.DateTime(),
            //            ConfirmationToken = c.String(maxLength: 128),
            //            IsConfirmed = c.Boolean(),
            //            LastPasswordFailureDate = c.DateTime(),
            //            PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
            //            Password = c.String(nullable: false, maxLength: 128),
            //            PasswordChangedDate = c.DateTime(),
            //            PasswordSalt = c.String(nullable: false, maxLength: 128),
            //            PasswordVerificationToken = c.String(maxLength: 128),
            //            PasswordVerificationTokenExpirationDate = c.DateTime(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.webpages_OAuthMembership",
            //    c => new
            //        {
            //            Provider = c.String(nullable: false, maxLength: 30),
            //            ProviderUserId = c.String(nullable: false, maxLength: 100),
            //            UserId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Provider, t.ProviderUserId })
            //    .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.webpages_Roles",
            //    c => new
            //        {
            //            RoleId = c.Int(nullable: false, identity: true),
            //            RoleName = c.String(maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.RoleId);
            
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //            EmailAddress = c.String(nullable: false),
            //            BFirstName = c.String(maxLength: 150),
            //            BLastName = c.String(maxLength: 150),
            //            BPhone = c.String(maxLength: 20),
            //            BAddressLine1 = c.String(maxLength: 250),
            //            BAddressLine2 = c.String(maxLength: 250),
            //            BCityProvince = c.String(maxLength: 250),
            //            BState = c.String(),
            //            BCountry = c.Int(),
            //            BPostal = c.String(),
            //            Active = c.Boolean(nullable: false),
            //            CompanyName = c.String(),
            //            SoftDelete = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
            //CreateTable(
            //    "dbo.User",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            UserName = c.String(),
            //            Password = c.String(),
            //            Email = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.webpages_UsersInRoles",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false),
            //            RoleId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
            //    .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            //DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Membership");
            //DropForeignKey("dbo.webpages_OAuthMembership", "UserId", "dbo.webpages_Membership");
            //DropForeignKey("dbo.EstimateFormInventory", "efRoom_RoomID", "dbo.Room");
            //DropForeignKey("dbo.EstimateFormInventory", "efInvItem_InventoryItemID", "dbo.InventoryItem");
            //DropForeignKey("dbo.Room", "EstimateForm_EstimateFormID", "dbo.EstimateForm");
            //DropForeignKey("dbo.InventoryItem", "EstimateForm_EstimateFormID", "dbo.EstimateForm");
            //DropForeignKey("dbo.InventoryItem", "Room_RoomID", "dbo.Room");
            //DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            //DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            //DropIndex("dbo.webpages_OAuthMembership", new[] { "UserId" });
            //DropIndex("dbo.EstimateFormInventory", new[] { "efRoom_RoomID" });
            //DropIndex("dbo.EstimateFormInventory", new[] { "efInvItem_InventoryItemID" });
            //DropIndex("dbo.Room", new[] { "EstimateForm_EstimateFormID" });
            //DropIndex("dbo.InventoryItem", new[] { "EstimateForm_EstimateFormID" });
            //DropIndex("dbo.InventoryItem", new[] { "Room_RoomID" });
            //DropTable("dbo.webpages_UsersInRoles");
            //DropTable("dbo.User");
            //DropTable("dbo.UserProfile");
            //DropTable("dbo.webpages_Roles");
            //DropTable("dbo.webpages_OAuthMembership");
            //DropTable("dbo.webpages_Membership");
            //DropTable("dbo.EstimateFormInventory");
            //DropTable("dbo.Room");
            //DropTable("dbo.InventoryItem");
            //DropTable("dbo.EstimateForm");
            //DropTable("dbo.CustomerEstimates");
            //DropTable("dbo.CustomerAddress");
            //DropTable("dbo.Content");
        }
    }
}
