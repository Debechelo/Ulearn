using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greedy.Architecture;
using System.Drawing;

namespace Greedy
{
    public class DijkstraData
    {
        public Point Previous { get; set; }
        public int Price { get; set; }
    }

    public class DijkstraPathFinder
    {
        public IEnumerable<PathWithCost> GetPathsByDijkstra(State state, Point start,
            IEnumerable<Point> targets)
        {
            foreach (var path in GetPaths(start, state, targets.ToList()))
            {
                yield return path;
            }
        }

        public IEnumerable<PathWithCost> GetPaths(Point start, State state, List<Point> targets)
        {
            var ñhests = new List<Point>(targets);
            var notAttend = new List<Point>(GetWalls(start, state));
            var attend = new List<Point>();
            notAttend.Add(start);
            bool flag = true;
            var track = new Dictionary<Point, DijkstraData>
            {
                [start] = new DijkstraData { Price = 0, Previous = new Point(int.MinValue, int.MinValue) }
            };

            while (!notAttend.Count.Equals(0) && flag)
            {
                var step = new Point(int.MinValue, int.MinValue);
                var price = double.PositiveInfinity;
                foreach (var e in notAttend)
                {
                    if (track.ContainsKey(e) && track[e].Price < price)
                    {
                        price = track[e].Price;
                        step = e;
                    }
                }

                toStep(state, step, track, notAttend, attend);

                if (ñhests.Contains(step) && flag)
                {
                    ñhests.Remove(step);
                    yield return GetPathWithPrice(track, step);
                }
            }
        }

        public IEnumerable<Point> GetWalls(Point toOpen, State state)
        {
            var walls = new List<Size>
            {
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0),
                new Size(0, -1)
            };

            foreach (var e in walls)
            {
                var next = toOpen + e;
                if (state.InsideMap(next) && state.CellCost[next.X, next.Y] != 0)
                {
                    yield return next;
                }
            }
        }

        public void toStep(State state, Point step, Dictionary<Point, DijkstraData> track,
            List<Point> notAttend, List<Point> attend)
        {

            bool priceWithStep = true;
            foreach (var e in GetWalls(step, state))
            {
                var price = track[step].Price + state.CellCost[e.X, e.Y];
                if (!attend.Contains(e) && priceWithStep)
                    notAttend.Add(e);
                if (!track.ContainsKey(e) || track[e].Price > price)
                {
                    track.Add(e, new DijkstraData { Previous = step, Price = price });
                }
                attend.Add(e);
            }

            attend.Add(step);
            notAttend.Remove(step);
        }

        public PathWithCost GetPathWithPrice(Dictionary<Point, DijkstraData> track, Point step)
        {
            var path = new List<Point>();
            var end = step;
            while (end != new Point(int.MinValue, int.MinValue))
            {
                path.Add(end);
                end = track[end].Previous;
            }
            path.Reverse();
            return new PathWithCost(track[step].Price, path.ToArray());
        }

        
    }
}