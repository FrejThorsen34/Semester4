using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I4DABH1NE84070
{
    class Program
    {
        static void Main (string[] args)
        {
            using (var db = new BloggingContext())
            {
                /*
                // Create and save a new Blog
                Console.Write("Enter the name for a new Blog: ");
                var blogName = Console.ReadLine();

                var blog = new Blog { Name = blogName };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Create and save a new organization
                Console.Write("Enter organization name: ");
                var orgName = Console.ReadLine();

                var organization = new Organization { OrganizationName = orgName };
                db.Organizations.Add(organization);
                db.SaveChanges();

                // Create and save a new user
                Console.Write("Enter user name: ");
                var userName = Console.ReadLine();

                var user = new User { Username = userName, Organization = organization };
                db.Users.Add(user);
                db.SaveChanges();
                */

                // Display all Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                // Display all Organizations from the database
                var query2 = from b in db.Organizations
                             orderby b.OrganizationName
                             select b;

                Console.WriteLine("All organizations in the database:");
                foreach (var item in query2)
                {
                    Console.WriteLine(item.OrganizationName);
                }

                // Display all Organizations from the database
                var query4 = from b in db.Countries
                             orderby b.CountryName
                             select b;

                Console.WriteLine("All countries in the database:");
                foreach (var item in query4)
                {
                    Console.WriteLine(item.CountryName);
                }

                // Display all Users from the database
                var query3 = from b in db.Users
                             orderby b.Username
                             select b;

                Console.WriteLine("All users in the database:");
                foreach (var item in query3)
                {
                    Console.WriteLine(item.Username);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }

    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public virtual List<Country> Homelands { get; set; }
    }

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }

        public virtual List<Organization> OrgsInCountry { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }
}
