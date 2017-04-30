using System;
using OdeToFood.Models;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    internal class RestaurantRater
    {
        private Restaurant _Restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._Restaurant = restaurant;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var result = new RatingResult();

            result.Rating = (int)_Restaurant.Reviews.Average(review => review.Rating);

            return result;
        }
    }
}