using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class TreeItem
    {
        public HashSet<TreeItem> Childs { get; set; }
        public TreeItem Parent { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool IsValid => Childs.Select(x => x.CalculatedWight).GroupBy(x => x).Count() > 1;
        public int CalculatedWight => Weight + Childs.Sum(x => x.CalculatedWight);
    }
}
