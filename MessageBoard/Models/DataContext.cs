using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MessageBoard.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}