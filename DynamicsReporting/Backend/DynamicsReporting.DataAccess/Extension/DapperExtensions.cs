using Dapper;
using DynamicsReporting.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

 
    public static class DapperExtensions
    {
        // ใช้ static compiled Regex เพื่อเพิ่มประสิทธิภาพ
        private static readonly Regex OrderByRegex = new Regex(@"\s+ORDER\s+BY\s+[\w\W]*", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex HasOrderByRegex = new Regex(@"\bORDER\s+BY\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Extension method สำหรับการแบ่งหน้า (pagination) ด้วย Dapper
        /// รวมการ validate parameter และใช้ QueryMultipleAsync เพื่อรวม query count กับ query data
        /// </summary>
        /// <typeparam name="T">ประเภทของข้อมูลที่จะดึง</typeparam>
        /// <param name="connection">ตัวเชื่อมต่อฐานข้อมูล (IDbConnection)</param>
        /// <param name="sql">
        /// SQL query หลักที่ต้องการดึงข้อมูล (สามารถมี WHERE และ/หรือ ORDER BY อยู่ได้)
        /// </param>
        /// <param name="param">Parameters สำหรับ SQL query</param>
        /// <param name="currentPage">หน้าปัจจุบัน (ต้องมากกว่าศูนย์)</param>
        /// <param name="pageSize">จำนวน record ต่อหน้า (ต้องมากกว่าศูนย์)</param>
        /// <returns>ผลลัพธ์แบบแบ่งหน้าในรูปแบบ </returns>
        public static async Task<PaginatedResult<T>> GetPaginatedResultAsync<T>(
            this IDbConnection connection,
            string sql,
            object param,
            int currentPage,
            int pageSize)
        {
            // Validate parameters
            if (connection == null)
                throw new ArgumentNullException(nameof(connection), "IDbConnection cannot be null.");
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL query cannot be null or empty.", nameof(sql));
            if (param == null)
                throw new ArgumentNullException(nameof(param), "Parameters for SQL query cannot be null.");
            if (currentPage <= 0)
                throw new ArgumentOutOfRangeException(nameof(currentPage), "Current page must be greater than zero.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");

            // ลบ ORDER BY สำหรับ count query
            string sqlWithoutOrderBy = OrderByRegex.Replace(sql, string.Empty);
            var countSql = $@"SELECT COUNT(1) FROM ({sqlWithoutOrderBy}) AS CountTable";

            // คำนวณ offset
            int offset = (currentPage - 1) * pageSize;

            // ตรวจสอบว่า SQL query มี ORDER BY อยู่หรือไม่
            bool hasOrderBy = HasOrderByRegex.IsMatch(sql);
            string paginatedSql = hasOrderBy
                ? $@"{sql} OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY"
                : $@"{sql} ORDER BY (SELECT NULL) OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            // รวม count query กับ paginated query ในคำสั่งเดียวเพื่อลด round-trip ไปยังฐานข้อมูล
            string combinedSql = $@"{countSql}; {paginatedSql}";

            using (var multi = await connection.QueryMultipleAsync(combinedSql, param))
            {
                int totalCount = await multi.ReadFirstAsync<int>();
                List<T> data = (await multi.ReadAsync<T>()).ToList();
                int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                return new PaginatedResult<T>
                {
                    Data = data,
                    Pagination = new Pagination
                    {
                        TotalRecords = totalCount,
                        PageSize = pageSize,
                        TotalPages = totalPages,
                        CurrentPage = currentPage
                    }
                };
            }
        }
    }
 
