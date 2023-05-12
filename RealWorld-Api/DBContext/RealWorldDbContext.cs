using System;
using System.Security.AccessControl;
// Purpose: Contains the RealWorldDbContext class which is used to connect to the database.

using RealWorld_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data;


namespace RealWorld_Api.DBContext
{

public class RealWorldDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
  /*  public DbSet<Article> Articles { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ArticleFavorite> ArticleFavorites { get; set; }
    public DbSet<UserFollow> UserFollows { get; set; }*/

    public RealWorldDbContext(DbContextOptions<RealWorldDbContext> options) : base(options)
    {
    }
    
}
}