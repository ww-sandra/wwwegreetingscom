﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace halloween.Models
{
    public class DataContext : DbContext
    {
   
        public DataContext() { }
        
        public DataContext(DbContextOptions<DataContext> options):
            base(options){ }

        DbSet<Contact> Contact { get; set; }

  
    }
}