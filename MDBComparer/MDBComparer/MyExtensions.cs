using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDBComparer
{
    internal static class MyExtensions
    {

        /// <summary>
        /// Correlates the elements of two sequences based on equality of keys and groups the results. The default equality comparer is used to compare keys
        /// </summary>
        /// <typeparam name="TA">The type of the elements of the first sequence</typeparam>
        /// <typeparam name="TB">The type of the elements of the second sequence.</typeparam>
        /// <typeparam name="TK">The type of the keys returned by the key selector functions</typeparam>
        /// <typeparam name="TR">The type of the result elements.</typeparam>
        /// <param name="a">The first sequence to join</param>
        /// <param name="b">The sequence to join to the first sequence</param>
        /// <param name="selectKeyA">A function to extract the join key from each element of the second sequence</param>
        /// <param name="selectKeyB">A function to create a result element from an element from the first sequence and a collection of matching elements from the second sequence.</param>
        /// <param name="projection"></param>
        /// <param name="cmp">A type comparer</param>
        /// <returns>An IEnumerable<T> that contains elements of type TResult that are obtained by performing a grouped join on two sequences.</returns>
        internal static IList<TR> FullOuterJoin<TA, TB, TK, TR>(
            this IEnumerable<TA> a,
            IEnumerable<TB> b,
            Func<TA, TK> selectKeyA,
            Func<TB, TK> selectKeyB,
            Func<TA, TB, TK, TR> projection,
            TA defaultA = default(TA),
            TB defaultB = default(TB),
            IEqualityComparer<TK> cmp = null)
        {
            cmp = cmp ?? EqualityComparer<TK>.Default;
            var alookup = a.ToLookup(selectKeyA, cmp);
            var blookup = b.ToLookup(selectKeyB, cmp);

            var keys = new HashSet<TK>(alookup.Select(p => p.Key), cmp);
            keys.UnionWith(blookup.Select(p => p.Key));

            var join = from key in keys
                       from xa in alookup[key].DefaultIfEmpty(defaultA)
                       from xb in blookup[key].DefaultIfEmpty(defaultB)
                       select projection(xa, xb, key);

            return join.ToList();
        }
    }
}
