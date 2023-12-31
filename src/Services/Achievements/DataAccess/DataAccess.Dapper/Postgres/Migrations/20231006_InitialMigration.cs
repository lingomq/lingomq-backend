﻿using FluentMigrator;

namespace Achievements.DataAccess.Dapper.Postgres.Migrations
{
    [Profile("Development")]
    [Migration(20231006)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsGuid().PrimaryKey().Unique().NotNullable()
                .WithColumn("email").AsCustom("varchar(256)").Unique().NotNullable()
                .WithColumn("phone").AsCustom("varchar(15)");

            Create.Table("achievements")
                .WithColumn("id").AsGuid().PrimaryKey().Unique().NotNullable()
                .WithColumn("name").AsCustom("varchar(50)").Unique().NotNullable()
                .WithColumn("content").AsCustom("varchar(100)").NotNullable()
                .WithColumn("image_uri").AsCustom("text").Nullable();

            Create.Table("user_achievements")
                .WithColumn("id").AsGuid().PrimaryKey().Unique().NotNullable()
                .WithColumn("achievement_id").AsGuid().NotNullable()
                .WithColumn("user_id").AsGuid().NotNullable()
                .WithColumn("date_of_receipt").AsDateTime().Nullable();

            Create.ForeignKey("FK_Achievements_UserAchievements_AchievementId")
                .FromTable("user_achievements").ForeignColumn("achievement_id")
                .ToTable("achievements").PrimaryColumn("id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_Achievements_UserAchievements_UserId")
                .FromTable("user_achievements").ForeignColumn("user_id")
                .ToTable("users").PrimaryColumn("id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

        }
        public override void Down()
        {
            Delete.Table("users");
            Delete.Table("achievements");
            Delete.Table("user_achievements");
        }
    }
}
