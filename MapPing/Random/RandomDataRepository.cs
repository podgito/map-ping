using MapPing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MapPing.Random
{
    public class RandomDataRepository : IRepository
    {

        const int maxLat = 55;
        const int minLat = 52;
        const int maxLong = -10;
        const int minLong = -6;

        System.Random generator;


        public RandomDataRepository() //set for ireland
        {
            generator = new System.Random();
        }

        public IEnumerable<MapEvent> GetMapEvents()
        {
            var count = generator.Next(1, 60);

            for(var i = 0; i< count; i++)
            {
                var lat = Generate(minLat, maxLat);
                var @long = Generate(minLong, maxLong);
                var val = GenerateGaussian(30, 10);
                yield return new MapEvent(lat, @long, val);
            }
        }

        private double Generate(int min, int max)
        {
            return generator.NextDouble() * (max - min) + min;
        }

        private double GenerateGaussian(double mean, double stdDev)
        {
            System.Random rand = new System.Random(); //reuse this if you are generating many
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal =
                         mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

            return randNormal;
        }

    }
}