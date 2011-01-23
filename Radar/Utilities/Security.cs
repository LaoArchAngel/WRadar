using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radar.Utilities
{
    public static class Security
    {
        private static readonly Random _random = new Random((int) DateTime.Now.Ticks);

        /// <summary>
        /// Creates a random string
        /// </summary>
        /// <param name="size">Size of the string you'd like</param>
        /// <returns>A random string.</returns>
        public static string RandomString(int size)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*_random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}