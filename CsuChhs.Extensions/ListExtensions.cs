namespace CsuChhs.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random rng = new Random();

        /// <summary>
        /// Attempts to randomly sort the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Adds the item to the list if it doesn't exist
        /// or removes if it does. This a short cut to using
        /// the .Contains(<T>) pattern.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddOrRemove<T>(this IList<T> list, T item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
            }
            else
            {
                list.Add(item);
            }
        }
    }
}
