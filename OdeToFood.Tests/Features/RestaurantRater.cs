using System;
using OdeToFood.Models;
using System.Linq;

namespace OdeToFood.Tests.Features
{
    public class RestaurantRater
    {
        private Restaurant _Restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._Restaurant = restaurant;
        }

        public  RatingResult ComputeWeightedRate(IRatingAlgorithm algorithm, int numberOfReviews)
        {
            return algorithm.Compute(_Restaurant.Reviews.ToList());
        }

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviews)
        {
            return algorithm.Compute(_Restaurant.Reviews.Take(numberOfReviews).ToList());
        }
    }
}