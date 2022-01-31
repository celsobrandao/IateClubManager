using System;

namespace IateClubMAnager.Tests.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random _random = new();

        public static int GetInt() => _random.Next();
        public static string GetString() => Guid.NewGuid().ToString();

    }
}
