using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10
{
    public static class KnotHash
    {
        private static IList<int> LengthSalt => new List<int> { 17, 31, 73, 47, 23 };

        public static string DenseHash(string lengths)
        {
            var roundTrips = 64;
            var hashSize = 256;

            var cnv = lengths
                        .Select(x => (int)x)
                        .Concat(LengthSalt)
                        .ToList();

            var spareseHash = SparseHash(hashSize, cnv, roundTrips);

            var denseHash = new StringBuilder();

            for(var block=0; block < 16; block++)
            {
                var result = 0;
                foreach(var i in spareseHash.Skip(16 * block).Take(16))
                {
                    result ^= i;
                }
                
                denseHash.Append(result.ToString("X2"));
            }

            return denseHash.ToString().ToLowerInvariant();
        }

        public static IList<int> SparseHash(int hashSize, IList<int> lengths, int roundTrips = 1)
        {
            var list = Enumerable.Range(0, hashSize).ToList();
            var listSize = list.Count;
            
            var pos = 0;
            var skip = 0;

            for (var roundTrip = 0; roundTrip < roundTrips; ++roundTrip)
            foreach(var len in lengths)
            {
                List<int> partition;
                if(pos + len > listSize)
                {
                    partition = list.GetRange(pos, listSize - pos)
                                    .Concat(list.GetRange(0, (pos + len) % listSize))
                                    .Reverse()
                                    .ToList();
                    
                    list.RemoveRange(pos, listSize - pos);
                    list.InsertRange(pos, partition.Take(listSize - pos));

                    list.RemoveRange(0, (pos + len) % listSize);
                    list.InsertRange(0, partition.Skip(listSize - pos));

                }
                else
                {
                    partition = list.GetRange(pos, len).AsEnumerable().Reverse().ToList();
                    list.RemoveRange(pos, len);
                    list.InsertRange(pos, partition);
                }

                pos = (pos + len + skip ) % listSize;

                skip++;
            }

            return list;
        }
    }
}
