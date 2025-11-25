using System;
using System.Collections.Generic;

namespace AGL.Helper
{
    internal static class MyRandom
    {
        private static Random _random = new Random();
        public static void Initialize(int seed) => _random = new Random(seed);
        public static int Rand(int r) => _random.Next(r);
        public static T Rand<T>(List<T> list) => list[_random.Next(list.Count)];

        internal static float Range(int v1, int v2) => _random.Next(v1, v2);
    }
}
