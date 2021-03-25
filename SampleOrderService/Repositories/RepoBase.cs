using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SampleOrderService.Repositories
{
    public abstract class RepoBase
    {
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
    }
}
