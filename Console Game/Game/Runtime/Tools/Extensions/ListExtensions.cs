using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame.Tools
{
    public static class ListExtensions
    {
        private static readonly Random _random;

        static ListExtensions()
        {
            _random = new Random();
        }

        public static T GetRandom<T>(this IReadOnlyList<T> list)
        {
            int randomIndex = _random.Next(0, list.Count);
            return list[randomIndex];
        }

        public static T GetRandom<T>(this IReadOnlyList<(T Element, float Chance)> list)
        {
            var sum = list.Sum(element => element.Chance);
            var randomValue = _random.NextDouble() * sum;

            for (var i = 0; i < list.Count; i++)
            {
                if (randomValue < list[i].Chance)
                {
                    return list[i].Element;
                }
                
                else
                {
                    randomValue -= list[i].Chance;
                }
            }

            return list.Last().Element;
        }
    }
}