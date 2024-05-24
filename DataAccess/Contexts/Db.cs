using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccess.Contexts;

public class Db : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Reading> Reading { get; set; }
    public DbSet<TarotCard> TarotCard { get; set; }

    public DbSet<UserReading> UserReading { get; set; }

    public Db(DbContextOptions options) : base(options)
    {
    }

 
}