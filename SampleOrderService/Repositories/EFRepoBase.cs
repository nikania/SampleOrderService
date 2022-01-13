using SampleOrderService.Repositories.EFCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace SampleOrderService.Repositories
{
    public abstract class EFRepoBase : IDisposable
    {
        private bool disposedValue;

        protected OrderDbContext DbContext { get; }

        protected EFRepoBase(OrderDbContext context)
        {
            DbContext = context ?? throw new ArgumentNullException(nameof(OrderDbContext));
        }

        public async Task Process(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch(DbException e)
            {
                throw e;
            }
        }

        public async Task<T> Process<T>(Func<Task<T>> action)
        {
            try
            {
                var result = await action();
                return result;
            }
            catch (DbException e)
            {
                throw e;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
