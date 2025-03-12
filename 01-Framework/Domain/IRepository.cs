using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Domain
{
    /// <summary>
    /// TKey=Type ID , T=Type entity
    /// در ریپازیتوری ها استفاده میکنیم
    /// </summary>
    /// <typeparam name="TKey">Type ID</typeparam>
    /// <typeparam name="T">Type entity -- type class --</typeparam>
    public interface IRepository<TKey , T> where T : class
    {
        /// <summary>
        /// بر اساس ایدی پیدا میکند
        /// </summary>
        /// <param name="Id">ایدی</param>
        /// <returns></returns>
        T Get(TKey Id);
        /// <summary>
        /// یک لیست برای ما برمیگردوند
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();
        /// <summary>
        /// بر اساس کلاسی سازنده برای ما موجودیتی میسازد
        /// </summary>
        /// <param name="entity">موجودیت</param>
        void Create(T entity);
        /// <summary>
        /// Save میکند
        /// </summary>
        void SaveChanges();
        /// <summary>
        /// بررسی وجود داشتن یک موجودیت
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>>expression);
    }
}
