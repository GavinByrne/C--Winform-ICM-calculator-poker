using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icmTest
{
    class Permutation
    {
        public IEnumerable<T[]> Enumerate<T>(IEnumerable<T> nums, int length)
        {
            return _GetPermutations<T>(new List<T>(), nums.ToList(), length);
        }

        private IEnumerable<T[]> _GetPermutations<T>(IEnumerable<T> perm, IEnumerable<T> nums, int length)
        {
            if (length - perm.Count() <= 0)
            {
                yield return perm.ToArray();
            }
            else
            {
                foreach (var n in nums)
                {
                    var result = _GetPermutations<T>(perm.Concat(new T[] { n }),
                        nums.Where(x => x.Equals(n) == false), length - perm.Count());

                    foreach (var xs in result)
                        yield return xs.ToArray();
                }
            }
        }
    }
}
