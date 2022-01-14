using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	public class BfsTask
	{
		public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
		{
			var chestsSet = new HashSet<Point>();
			var visited = new HashSet<Point>();
			var queue = new Queue<SinglyLinkedList<Point>>();
			foreach (var chest in chests)
				chestsSet.Add(chest);
			visited.Add(start);
			queue.Enqueue(new SinglyLinkedList<Point>(start));
			while (queue.Count != 0)
			{
				var point = queue.Dequeue();
				for (var dy = -1; dy <= 1; dy++)
					for (var dx = -1; dx <= 1; dx++)
						if (dx != 0 && dy != 0) continue;
						else
						{
							var step = new Point(point.Value.X + dx, point.Value.Y + dy);
							if (!map.InBounds(step) || visited.Contains(step)) continue;
							if (map.Dungeon[point.Value.X + dx, point.Value.Y + dy] != MapCell.Wall)
							{
								var tail = new SinglyLinkedList<Point>(step, point);
								visited.Add(step);
								queue.Enqueue(tail);
								if (chestsSet.Contains(step))
									yield return tail;
							}
						}
			}
			yield break;
		}
	}
}