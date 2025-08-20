using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.Shared.Helpers
{
    public class Pagination
    {
        /// <summary>
        /// เลขหน้าปัจจุบัน (Page Index)
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        /// จำนวนรายการต่อหน้า (Page Size)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// จำนวนรายการทั้งหมด
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// จำนวนหน้าทั้งหมด
        /// </summary>
        public int TotalPages { get; set; }
    }

    /// <summary>
    /// API Response สำหรับกรณีที่ข้อมูลส่งกลับเป็นแบบแบ่งหน้า (Pagination)
    /// </summary>
    /// <typeparam name="TData">ประเภทข้อมูลในแต่ละรายการ</typeparam>
    //public class PaginatedResult<TData> : ErrorResponse
    //{
    //    /// <summary>
    //    /// ข้อมูล
    //    /// </summary>
    //    public List<TData> Data { get; set; } = new List<TData>();
    //    /// <summary>
    //    /// รายละเอียดการแบ่งหน้า
    //    /// </summary>
    //    public Pagination Pagination { get; set; } = new Pagination();
    //}


    public class PaginatedResult<T> : ErrorResponse
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public string? ErrorMessage { get; set; }
    }



}
