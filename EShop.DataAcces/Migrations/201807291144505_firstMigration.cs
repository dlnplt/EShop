namespace EShop.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddresDetail = c.String(),
                        County_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Counties", t => t.County_ID)
                .Index(t => t.County_ID);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Discount = c.Int(nullable: false),
                        Resim_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resims", t => t.Resim_ID)
                .Index(t => t.Resim_ID);
            
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageType = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        Deleted = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        UstKategoriID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        Deleted = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        Deleted = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddresDetail_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressDetails", t => t.AddresDetail_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.AddresDetail_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Customers", "AddresDetail_ID", "dbo.AddressDetails");
            DropForeignKey("dbo.Brands", "Resim_ID", "dbo.Resims");
            DropForeignKey("dbo.Resims", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.AddressDetails", "County_ID", "dbo.Counties");
            DropForeignKey("dbo.Counties", "City_ID", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Customers", new[] { "User_ID" });
            DropIndex("dbo.Customers", new[] { "AddresDetail_ID" });
            DropIndex("dbo.Carts", new[] { "Customer_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Resims", new[] { "Product_ID" });
            DropIndex("dbo.Brands", new[] { "Resim_ID" });
            DropIndex("dbo.Counties", new[] { "City_ID" });
            DropIndex("dbo.AddressDetails", new[] { "County_ID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Resims");
            DropTable("dbo.Brands");
            DropTable("dbo.Cities");
            DropTable("dbo.Counties");
            DropTable("dbo.AddressDetails");
        }
    }
}
