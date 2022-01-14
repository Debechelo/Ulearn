using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;

namespace Greedy
{
	public class GreedyPathFinder : IPathFinder
	{
		public List<Point> FindPathToCompleteGoal(State state)
		{
			if (state.Goal == 0)
				return new List<Point>();

			HashSet<Point> chests = new HashSet<Point>(state.Chests);
			DijkstraPathFinder dijkstraPathFinder = new DijkstraPathFinder();
			List<Point> path = new List<Point>();
			bool flag = false;

			var price = 0;
			var position = state.Position;

			for (int i = 0; i < state.Goal; i++)
			{
				if (!chests.Any() && !flag)
					return new List<Point>();
				PathWithCost toChest = dijkstraPathFinder.GetPathsByDijkstra(state, position, chests).FirstOrDefault();
				if (toChest == null)
					return new List<Point>();
				position = toChest.End;
				price += toChest.Cost;
				if (price > state.Energy)
					return new List<Point>();
				chests.Remove(toChest.End);

				for (int j = 1; j < toChest.Path.Count; j++)
					path.Add(toChest.Path[j]);
			}

			return path;
		}
	}
}