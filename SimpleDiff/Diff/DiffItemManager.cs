using SimpleDiff.Extensions;
using SimpleDiff.Helpers;
using SimpleDiff.Models;

namespace SimpleDiff.Diff
{
    public sealed class DiffItemManager
    {
        #region Properties
        private IDiffItemStore DiffItemStore { get; }

        public const string DIFFERENT_SIZE = "inputs are of different size";

        public const string EQUAL_INPUTS = "inputs were equal";
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="diffItemStore"></param>
        public DiffItemManager(IDiffItemStore diffItemStore)
        {
            DiffItemStore = diffItemStore;
        }

        /// <summary>
        /// Create Item with params
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<Result> CreateItemAsync(int id, DiffType type, string value)
        {
            return await DiffItemStore.CreateItemAsync(new DiffItem { Id = id, Type = type, Value = value });
        }

        /// <summary>
        /// Get result for a item by id.
        /// There must be two items to get a string result.
        /// The result can be a different size or the same value of inputs or a calculation of differences of inputs.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string?> GetResultForItemAsync(int id)
        {
            var items = await DiffItemStore.FindItemsById(id);
            if (items.Count != 2) return null;

            if (items[0].Value.Length != items[1].Value.Length) return DIFFERENT_SIZE;
            
            if (items[0].Value.Equals(items[1].Value)) return EQUAL_INPUTS;

            return DiffHelper.GetDiff(items[0].Value, items[1].Value).ToDiffString();
        }
        
    }
}
