﻿using System;
using Microsoft.EntityFrameworkCore;
using Whats_Cookin.Server.Models;
namespace Whats_Cookin.Server
{
    public class ServerContext:DbContext
    {
        public DbSet<Users> Users {  get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        public DbSet<Food_Items> Food_Items { get; set; }
        public DbSet<Prebookings> Prebookings { get; set; }
        public DbSet<Likes> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BERLIN;Database=WhatsCookin;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
