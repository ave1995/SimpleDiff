namespace SimpleDiff.Extensions
{
    public static class DictionaryExtension
    {
        public static string ToDiffString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(" ", dictionary.Select(kv => "[offset " + kv.Key + ", length " + kv.Value + "]").ToArray()) + "}";
        }
    }
}
