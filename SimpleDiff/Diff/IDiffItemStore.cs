using SimpleDiff.Models;

namespace SimpleDiff.Diff
{
    public interface IDiffItemStore
    {
        public Task<DiffItem?> FindItemAsync(int id, DiffType type, CancellationToken cancellationToken = default);

        public Task<IList<DiffItem>> FindItemsById(int id, CancellationToken cancellationToken = default);

        public Task<Result> CreateItemAsync(DiffItem item, CancellationToken cancellationToken = default);
    }
}
