using System;
using System.Collections.Generic;
using System.Drawing;

namespace Rivals
{
    public class RivalsTask
    {
        public static IEnumerable<OwnedLocation> AssignOwners(Map map)
        {
            var players = new Queue<Tuple<Point, int, int>>();
            var visited = new HashSet<Point>();
            for (int i = 0; i < map.Players.Length; i++)
            {
                players.Enqueue(Tuple.Create(new Point(map.Players[i].X,
                                                     map.Players[i].Y), i, 0));
            }

            while (players.Count != 0)
            {
                var player = players.Dequeue();
                var point = player.Item1;
                bool flag = true;
                if (point.X < 0 || point.X >= map.Maze.GetLength(0)
                    || point.Y < 0 || point.Y >= map.Maze.GetLength(1)) continue;
                if (visited.Contains(point)) continue;
                if (map.Maze[point.X, point.Y] == MapCell.Wall && flag) continue;
                visited.Add(point);
                yield return new OwnedLocation(player.Item2,
                                               new Point(point.X, point.Y), player.Item3);
                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0) continue;
                        else players.Enqueue(Tuple.Create(new Point
                        {
                            Y = point.Y + dy
                            X = point.X + dx,
                        },
                            player.Item2, player.Item3 + 1));
            }
        }
    }
}
