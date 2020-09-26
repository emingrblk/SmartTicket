namespace SmartTicket.DataAccess.Migrations
{
    using SmartTicket.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartTicket.DataAccess.EntityFramework.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SmartTicket.DataAccess.EntityFramework.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //ana (root) menuler
            for (int i = 0; i < 3; i++)
            {
                EndlessCategory cat = new EndlessCategory()
                {
                    Name = $"Root Menu {i}",
                    ParentCategory = null,
                    OrderNo = i,
                    ControllerName = "Home",
                    ActionName = "Index"
                };
                context.EndlessCategories.Add(cat);
            }
            context.SaveChanges();

            //root kategoriler altýndaki sub kategoriler
            foreach (EndlessCategory rootcat in context.EndlessCategories.Where(a => a.ParentCategory == null))
            {
                for (int i = 0; i < 3; i++)
                {
                    EndlessCategory subCat = new EndlessCategory()
                    {
                        Name = $"Sub Menu {i}",
                        ParentCategory = rootcat,
                        //ParentCategoryId=rootcat.Id,
                        OrderNo = i,
                        ControllerName = "Home",
                        ActionName = "Index"
                    };
                    context.EndlessCategories.Add(subCat);
                }
            }
            context.SaveChanges();

            //Sub kategoriler altýndaki sub sub kategoriler insert edilir.
            foreach (EndlessCategory subCat in context.EndlessCategories.Where(a => a.ParentCategory != null))
            {
                for (int i = 0; i < 3; i++)
                {
                    EndlessCategory sub2Cat = new EndlessCategory()
                    {
                        Name = $"Sub Sub Menu{i}",
                        ParentCategory = subCat,
                        OrderNo = i,
                        ControllerName = "Home",
                        ActionName = "Index"
                    };
                    context.EndlessCategories.Add(sub2Cat);
                }
            }
            context.SaveChanges();
        }
    }
}