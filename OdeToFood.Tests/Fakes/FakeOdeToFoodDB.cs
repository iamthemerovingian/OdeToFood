using System;
using System.Linq;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Tests.Controllers
{
    public class FakeOdeToFoodDB : IOdeToFoodDb
    {
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();

        public void Dispose() { }

        public void AddSet<T>(IQueryable<T> objects)
        {
            Sets.Add(typeof(T), objects);
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IQueryable<T>;
        }
    }
}