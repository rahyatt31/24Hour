namespace _24Hour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserID = c.Guid(nullable: false),
                        PostID = c.Int(nullable: false),
                        Post_PostID = c.Int(),
                        CommentPost_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Post", t => t.Post_PostID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.CommentPost_PostID, cascadeDelete: false)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PostID)
                .Index(t => t.Post_PostID)
                .Index(t => t.CommentPost_PostID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        PostID = c.Int(nullable: false),
                        CommentID = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Post_PostID = c.Int(),
                        LikedPost_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikeID)
                .ForeignKey("dbo.Comment", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_PostID)
                .ForeignKey("dbo.Post", t => t.LikedPost_PostID, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.PostID)
                .Index(t => t.CommentID)
                .Index(t => t.Post_PostID)
                .Index(t => t.LikedPost_PostID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(nullable: false),
                        PostText = c.String(nullable: false),
                        UserID = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Reply",
                c => new
                    {
                        ReplyID = c.Int(nullable: false, identity: true),
                        ReplyTitle = c.String(nullable: false),
                        ReplyText = c.String(nullable: false),
                        UserID = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReplyID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ReplyComment",
                c => new
                    {
                        Reply_ReplyID = c.Int(nullable: false),
                        Comment_CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reply_ReplyID, t.Comment_CommentID })
                .ForeignKey("dbo.Reply", t => t.Reply_ReplyID, cascadeDelete: true)
                .ForeignKey("dbo.Comment", t => t.Comment_CommentID, cascadeDelete: true)
                .Index(t => t.Reply_ReplyID)
                .Index(t => t.Comment_CommentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "CommentPost_PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Reply", "UserID", "dbo.User");
            DropForeignKey("dbo.ReplyComment", "Comment_CommentID", "dbo.Comment");
            DropForeignKey("dbo.ReplyComment", "Reply_ReplyID", "dbo.Reply");
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropForeignKey("dbo.Like", "UserID", "dbo.User");
            DropForeignKey("dbo.Like", "LikedPost_PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "UserID", "dbo.User");
            DropForeignKey("dbo.Like", "Post_PostID", "dbo.Post");
            DropForeignKey("dbo.Comment", "Post_PostID", "dbo.Post");
            DropForeignKey("dbo.Like", "CommentID", "dbo.Comment");
            DropIndex("dbo.ReplyComment", new[] { "Comment_CommentID" });
            DropIndex("dbo.ReplyComment", new[] { "Reply_ReplyID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Reply", new[] { "UserID" });
            DropIndex("dbo.Post", new[] { "UserID" });
            DropIndex("dbo.Like", new[] { "LikedPost_PostID" });
            DropIndex("dbo.Like", new[] { "Post_PostID" });
            DropIndex("dbo.Like", new[] { "CommentID" });
            DropIndex("dbo.Like", new[] { "PostID" });
            DropIndex("dbo.Like", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "CommentPost_PostID" });
            DropIndex("dbo.Comment", new[] { "Post_PostID" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropTable("dbo.ReplyComment");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Reply");
            DropTable("dbo.Post");
            DropTable("dbo.Like");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
        }
    }
}
