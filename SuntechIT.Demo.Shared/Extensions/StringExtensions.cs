

namespace SuntechIT.Demo.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string someString) => string.IsNullOrEmpty(someString);

        public static bool IsNullOrWhiteSpace(this string someString) => string.IsNullOrWhiteSpace(someString);

        public static bool IsNotNullOrEmpty(this string someString) => !string.IsNullOrEmpty(someString);

        public static bool IsNotNullOrWhiteSpace(this string someString) => !string.IsNullOrWhiteSpace(someString);

    }
}
