using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
   public interface ISort<T>
    {
        void ApplySort(ref IQueryable<T> T, string orderByQueryString);
    }
}
