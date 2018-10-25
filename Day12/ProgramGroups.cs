using System.Collections.Generic;
using System.Linq;

namespace Day12
{
    public class ProgramGroups
    {
        private IDictionary<string, List<string>> mappings;
        public ProgramGroups(IDictionary<string, List<string>> mappings)
        {
            // Add bi-directional relations
            foreach (var mapping in mappings.Keys.ToList())
            {
                mappings[mapping].AddRange(mappings.Where(x => x.Value.Contains(mapping)).Select(x => x.Key));
                mappings[mapping] = mappings[mapping].Distinct().ToList();
            }

            this.mappings = mappings;
        }

        public int GetUniqeGroups()
        {
            var result = new HashSet<HashSet<string>>();
            foreach(var key in mappings.Keys)
            {
                var group = GetConnected(key);
                if(!result.Any(r => AnyDuplicants(r, group)))
                {
                    result.Add(group);
                }
            }
            return result.Count;
        }

        private bool AnyDuplicants(HashSet<string> a, HashSet<string> b)
        {
            return a.Any(x => b.Contains(x));
        }

        public HashSet<string> GetConnected(string id)
        {
            var result = mappings[id].ToHashSet();

            var queue = new Queue<string>(result.ToList());
            while (queue.Count > 0)
            {
                var items = mappings[queue.Dequeue()];
                foreach (var item in items)
                {
                    if (result.Add(item))
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return result;
        }
    }
}
