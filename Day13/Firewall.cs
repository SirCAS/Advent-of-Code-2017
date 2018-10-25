using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    public class Firewall
    {
        public Firewall(IDictionary<int, Layer> layers)
        {
            this.PlayerPos = -1;
            this.Layers = layers;
            this.Caught = new List<int>();
        }
        
        public void TickLayers()
        {
            foreach (var l in Layers)
            {
                l.Value.Tick();
            }
        }

        public bool Tick()
        {
            if (PlayerPos == Layers.Keys.Max())
            {
                return false;
            }

            PlayerPos++;

            if (Layers.ContainsKey(PlayerPos) && Layers[PlayerPos].ScannerPos == 0)
            {
                Caught.Add(PlayerPos);
            }

            TickLayers();

            return true;
        }

        public int Severity
        {
            get
            {
                var score = 0;
                foreach (var c in Caught)
                {
                    score += Layers[c].Range * c;
                }
                return score;
            }
        }

        public IList<int> Caught { get; set; }
        public IDictionary<int, Layer> Layers { get; set; }
        public int PlayerPos { get; set; }
    }
}
