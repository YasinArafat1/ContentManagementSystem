namespace Class_012_Practices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        PublishDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ArticleId);
            
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.TagId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleTags", new[] { "TagId" });
            DropIndex("dbo.ArticleTags", new[] { "ArticleId" });
            DropTable("dbo.Tags");
            DropTable("dbo.ArticleTags");
            DropTable("dbo.Articles");
        }
    }
}
