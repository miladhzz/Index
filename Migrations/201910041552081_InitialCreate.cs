namespace Index.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Datasets",
                c => new
                    {
                        DatasetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DatasetId);
            
            CreateTable(
                "dbo.Sentences",
                c => new
                    {
                        SentenceId = c.Int(nullable: false, identity: true),
                        Dataset_version = c.String(),
                        Generator = c.String(),
                        News_uniqe_id = c.String(),
                        Sentence_order = c.Int(nullable: false),
                        Sentence_id = c.String(),
                        Date_time = c.String(),
                        Text = c.String(),
                        DatasetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SentenceId)
                .ForeignKey("dbo.Datasets", t => t.DatasetId, cascadeDelete: true)
                .Index(t => t.DatasetId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        WordId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Role = c.String(),
                        Root = c.String(),
                        SentenceId = c.Int(nullable: false),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.WordId)
                .ForeignKey("dbo.Sentences", t => t.SentenceId, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.ParentID)
                .Index(t => t.SentenceId)
                .Index(t => t.ParentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "ParentID", "dbo.Words");
            DropForeignKey("dbo.Words", "SentenceId", "dbo.Sentences");
            DropForeignKey("dbo.Sentences", "DatasetId", "dbo.Datasets");
            DropIndex("dbo.Words", new[] { "ParentID" });
            DropIndex("dbo.Words", new[] { "SentenceId" });
            DropIndex("dbo.Sentences", new[] { "DatasetId" });
            DropTable("dbo.Words");
            DropTable("dbo.Sentences");
            DropTable("dbo.Datasets");
        }
    }
}
