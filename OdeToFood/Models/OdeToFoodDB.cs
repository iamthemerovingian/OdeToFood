﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public interface IOdeToFoodDb : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
    }

    public class OdeToFoodDb :DbContext, IOdeToFoodDb
    {
        public OdeToFoodDb() : base("name = DefaultConnection")
        {

        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}