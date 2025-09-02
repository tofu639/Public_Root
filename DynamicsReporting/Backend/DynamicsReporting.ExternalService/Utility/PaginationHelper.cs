using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicsReporting.ExternalService.Utility
{
    //    public class PaginatedResult<T>
    //    {
    //        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    //        public int TotalCount { get; set; }
    //        public int Page { get; set; }
    //        public int PageSize { get; set; }
    //        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

    //        public bool HasPreviousPage => Page > 1;
    //        public bool HasNextPage => Page < TotalPages;
    //    }

    //    public static class PaginationHelper
    //    {
    //        /// <summary>
    //        /// ทำการ paginate จาก IQueryable/Enumerable
    //        /// </summary>
    //        public static PaginatedResult<T> Paginate<T>(
    //            IEnumerable<T> source,
    //            int page,
    //            int pageSize)
    //        {
    //            if (page <= 0) page = 1;
    //            if (pageSize <= 0) pageSize = 10;

    //            var totalCount = source.Count();
    //            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

    //            return new PaginatedResult<T>
    //            {
    //                Items = items,
    //                TotalCount = totalCount,
    //                Page = page,
    //                PageSize = pageSize
    //            };
    //        }

    //        /// <summary>
    //        /// สำหรับ query จาก DB โดยตรง (เช่น Dapper/EF)
    //        /// return ค่า skip/take เฉย ๆ
    //        /// </summary>
    //        public static (int Offset, int Fetch) GetOffsetFetch(int page, int pageSize)
    //        {
    //            if (page <= 0) page = 1;
    //            if (pageSize <= 0) pageSize = 10;

    //            int offset = (page - 1) * pageSize;
    //            return (offset, pageSize);
    //        }
    //    }
    //}
}