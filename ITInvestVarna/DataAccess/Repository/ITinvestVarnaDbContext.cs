using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ITinvestVarnaDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        public ITinvestVarnaDbContext() : base("ITinvestVarnaDbConnection")
        {
            this.Users = this.Set<User>();
            this.Articles = this.Set<Article>();
            this.Categories = this.Set<Category>();
            this.Comments = this.Set<Comment>();
            this.KeyWords = this.Set<KeyWord>();
            this.Addresses = this.Set<Address>();
            this.PhoneNumbers = this.Set<PhoneNumber>();
            this.Galleries = this.Set<Gallery>();
            this.SearchHistories = this.Set<SearchHistory>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             

            modelBuilder.Entity<Article>()
                  .Property(a => a.DateTime)
                  .HasColumnType("datetime2")
                  .HasPrecision(0);

            modelBuilder.Entity<Article>()
                 .Property(a => a.DateTimeModified)
                 .HasColumnType("datetime2")
                 .HasPrecision(0);

            modelBuilder.Entity<Article>()
                 .Property(a => a.StartDateTime)
                 .HasColumnType("datetime2")
                 .HasPrecision(0);

            modelBuilder.Entity<Article>()
                 .Property(a => a.EndDateTime)
                 .HasColumnType("datetime2")
                 .HasPrecision(0);

            modelBuilder.Entity<Comment>()
                .Property(c => c.DateTime )
                .HasColumnType("datetime2")
                .HasPrecision(0);

            modelBuilder.Entity<Comment>()
               .Property(c => c.DateTimeModified)
               .HasColumnType("datetime2")
               .HasPrecision(0);

            modelBuilder.Entity<SearchHistory>()
               .Property(s => s.DateTime)
               .HasColumnType("datetime2")
               .HasPrecision(0);

            modelBuilder.Entity<User>()
            .HasMany(x => x.Ratings)
            .WithRequired(x => x.UserBeingRated)
            .HasForeignKey(x => x.UserIdBeingRated)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
               .Property(c => c.Name)
               .IsRequired();

        }
    }
}
