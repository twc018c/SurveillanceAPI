using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Surveillance.Schafold {

    /// <summary>
    /// LINQ擴充
    /// </summary>
    public static class LinqExtension {

        /// <summary>
        /// 非同步疊代
        /// </summary>
        /// <param name="_List">清單</param>
        /// <param name="_Func">代理</param>
        /// <returns>Task</returns>
        public static async Task ForEachAsync<T>(this List<T> _List, Func<T, Task> _Func) {
            foreach (T Value in _List) {
                await _Func(Value);
            }
        }


        /// <summary>
        /// 非同步疊代索引
        /// </summary>
        /// <param name="_List">清單</param>
        /// <param name="_Func">代理</param>
        /// <returns>Task</returns>
        public static async Task ForEachWithIndexAsync<T>(this List<T> _List, Func<T, int, Task> _Func) {
            foreach ((T Item, int Index) in _List.WithIndex()) {
                await _Func(Item, Index);
            }
        }


        /// <summary>
        /// 索引清單
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>List</returns>
        public static List<(T Item, int Index)> ToListIndex<T>(this List<T> _List) {
            var List = new List<(T Item, int Index)>();

            foreach ((T Item, int Index) in _List.WithIndex()) {
                List.Add((Item, Index));
            }

            return List;
        }


        /// <summary>
        /// 取得容器清單首個物件
        /// </summary>
        /// <param name="_Source">容器</param>
        /// <returns>T</returns>
        public static T FirstSafety<T>(this IEnumerable<T> _Source) {
            if (_Source != null && _Source.Count() > 0) {
                var List = _Source.ToList();
                return List.FirstOrDefault();
            } else {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }


        /// <summary>
        /// 過濾
        /// </summary>
        /// <param name="_Source">容器</param>
        /// <param name="_KeySelector">選取器</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> _Source, Func<TSource, TKey> _KeySelector) {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in _Source) {
                if (seenKeys.Add(_KeySelector(element))) {
                    yield return element;
                }
            }
        }


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="_Queryable">容器</param>
        /// <returns>bool</returns>
        public static bool IsOrdered<TSource>(this IQueryable<TSource> _Queryable) {
            if (_Queryable == null) {
                throw new ArgumentNullException("queryable");
            }

            return _Queryable.Expression.Type == typeof(IOrderedQueryable<TSource>);
        }


        /// <summary>
        /// 子狀態昇冪排序
        /// </summary>
        /// <param name="_Queryable">容器</param>
        /// <param name="_KeySelector">選取器</param>
        /// <returns>IQueryable</returns>
        public static IQueryable<TSource> OrderBySubStatus<TSource, TKey>(this IQueryable<TSource> _Queryable, Expression<Func<TSource, TKey>> _KeySelector) {
            return _Queryable;
        }


        /// <summary>
        /// 子狀態降冪排序
        /// </summary>
        /// <param name="_Queryable">容器</param>
        /// <param name="_KeySelector">選取器</param>
        /// <returns></returns>
        public static IQueryable<TSource> OrderBySubStatusDescending<TSource, TKey>(this IQueryable<TSource> _Queryable, Expression<Func<TSource, TKey>> _KeySelector) {
            return _Queryable;
        }


        /// <summary>
        /// 欄位挑選
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_Source">容器</param>
        /// <param name="_Method">函式</param>
        /// <returns>IEnumerable</returns>
        public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(this IEnumerable<TSource> _Source, Func<TSource, Task<TResult>> _Method) {
            return await Task.WhenAll(_Source.Select(async s => await _Method(s)));
        }


        /// <summary>
        /// 欄位挑選
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="_Source">容器</param>
        /// <param name="_Selector">選取器</param>
        /// <returns>IEnumerable</returns>
        public static async Task<IEnumerable<TResult>> SelectInSequenceAsync<TSource, TResult>(this IEnumerable<TSource> _Source, Func<TSource, Task<TResult>> _Selector) {
            var List = new List<TResult>();

            foreach (var s in _Source) {
                List.Add(await _Selector(s));
            }

            return List;
        }


        /// <summary>
        /// 索引位置
        /// </summary>
        /// <param name="_Source">容器</param>
        /// <returns>IEnumerable</returns>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> _Source) {
            return _Source.Select((Item, Index) => (Item, Index));
        }
    }
}