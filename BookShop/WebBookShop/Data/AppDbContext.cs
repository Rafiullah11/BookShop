﻿using Microsoft.EntityFrameworkCore;
using WebBookShop.Models;

namespace WebBookShop.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
