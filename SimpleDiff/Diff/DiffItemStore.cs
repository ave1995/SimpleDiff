using Microsoft.EntityFrameworkCore;
using SimpleDiff.Data;
using SimpleDiff.Models;

namespace SimpleDiff.Diff
{
    public sealed class DiffItemStore : IDiffItemStore
    {
        public DiffItemStore(DiffContext diffContext)
        {
            DiffContext = diffContext;
        }

        private DiffContext DiffContext { get; set; }

        private DbSet<DiffItem> DiffItems { get { return DiffContext.Set<DiffItem>(); } }

        public async Task<Result> CreateItemAsync(DiffItem item, CancellationToken cancellationToken = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            DiffItems.Add(item);
            try 
            {
                await DiffContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.OK();
        }

        public async Task<DiffItem?> FindItemAsync(int id, DiffType type, CancellationToken cancellationToken = default)
            => await DiffItems.FindAsync(new object?[] { id, type}, cancellationToken: cancellationToken);

        public async Task<IList<DiffItem>> FindItemsById(int id, CancellationToken cancellationToken = default)
            => await DiffItems.Where(i => i.Id == id).ToListAsync(cancellationToken);
    }
}
