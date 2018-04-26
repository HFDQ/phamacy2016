using System.Collections.Generic;
using System.Linq;

namespace BugsBox.Application.Core
{
    public class PagerInfo
    {
        public PagerInfo()
        {
            Index = 1;
            Size = 20; 
        }

        public int RecordCount { get; set; }

        public int Index { get; set; }

        public int Size { get; set; } 

        public static PagerInfo Validate(PagerInfo pager)
        {
            if (pager == null)
            {
                return new PagerInfo();
            }
            if (pager.Index < 1)
            {
                pager.Index = 1;
            }
            if (pager.Size <1)
            {
                pager.Size = 20;
            }
            return pager;
        }
    }

    public class PagerQuery<TEntity>
        where TEntity : class,new()
    {
        public PagerQuery(PagerInfo pager)
        {
            this.Pager = pager;
            this.DataList = Enumerable.Empty<TEntity>();
        }

        public PagerInfo Pager { get; protected set; }

        public IEnumerable<TEntity> DataList { get; set; }
    }
}