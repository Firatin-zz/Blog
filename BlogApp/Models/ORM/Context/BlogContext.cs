using BlogApp.Migrations;
using BlogApp.Models.Entity;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Context
{
    public class BlogContext:DbContext
    {
        public BlogContext()
        {
            //Database.Connection.ConnectionString =
            //    @"Server=95.173.170.161.\MSSQLSERVER2014;Database=sevgiyil_blog;UID=sevgiyil_admin;pwd=Jhk^62q2;";
            // auto migration için gereken tek satırlık kdtur.Herhangi bir instance alındığında modellere bakar
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<SiteMenu> SiteMenus { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<Hakkimda> Hakkimdas { get; set; }
        public DbSet<Kararlar> Kararlars { get; set; }

    }
}