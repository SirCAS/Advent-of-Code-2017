using System;
using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class DiscTree
    {
        private class StrDisc
        {
            public HashSet<string> Childs { get; set; }
            public string Name { get; set; }
            public string Weight { get; set; }
        }

        private HashSet<StrDisc> Discs { get; }
        
        public TreeItem Root { get; }

        public DiscTree(string[] input)
        {
            this.Discs = input.Select(l => new StrDisc {
                Name = l.Split(' ')[0],
                Weight = l.Split(new []{'(', ')'})[1],
                Childs =
                    l.Contains('>') ? l.Split('>')[1]
                                        .Substring(1)
                                        .Replace(" ", "")
                                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .ToHashSet()
                                            : new HashSet<string>()
            }).ToHashSet();

            var bottom = this.Discs.Single(x => this.Discs.All(u => !u.Childs.Contains(x.Name))).Name;

            this.Root = GetChild(null, bottom);
        }

        public void Traverse(TreeItem node, ref HashSet<(TreeItem, int)> result, int counter)
        {
            if(!node.IsValid)
            {
                result.Add((node, counter));
            } else {
                foreach(var kid in node.Childs)
                {
                    Traverse(kid, ref result, counter + 1);
                }
            }
        }


        private TreeItem GetChild(TreeItem parent, string name)
        {
            var child = Discs.Single(x => x.Name == name);

            var thisParent = new TreeItem 
            {
                Name = name,
                Weight = int.Parse(child.Weight),
                Parent = parent
            };

            thisParent.Childs = child.Childs.Select(x => GetChild(thisParent, x)).ToHashSet();

            return thisParent;
        }

    }
}
