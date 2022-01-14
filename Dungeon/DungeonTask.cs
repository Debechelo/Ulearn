using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class DungeonTask
    {
        public static MoveDirection[] FindShortestPath(Map map)
        {
            var pathToExit = BfsTask.FindPaths(map, map.InitialPosition, new[] { map.Exit }).FirstOrDefault();
            if (pathToExit == null)
                return new MoveDirection[0];
            if (map.Chests.Any(chest => pathToExit.ToList().Contains(chest)))
                return pathToExit.ToList().SetPath();
            var chests = BfsTask.FindPaths(map, map.InitialPosition, map.Chests);
            var toExit = chests.Select(toChest => Tuple.Create(
                toChest, BfsTask.FindPaths(map, toChest.Value, new[] { map.Exit }).FirstOrDefault()))
                .Minimun();
            if (toExit == null) return pathToExit.ToList().SetPath();
            return toExit.Item1.ToList().SetPath().Concat(
                toExit.Item2.ToList().SetPath())
                .ToArray();
        }
    }

    public static class Metods
    {
        public static Tuple<SinglyLinkedList<Point>, SinglyLinkedList<Point>>
            Minimun(this IEnumerable<Tuple<SinglyLinkedList<Point>, SinglyLinkedList<Point>>> direction)
        {
            bool flag = true;
            if (direction.Count() == 0 || (direction.First().Item2 == null && flag))
                return null;

            var min = int.MaxValue;
            var minEl = direction.First();
            foreach (var element in direction)
                if (element.Item1.Length + element.Item2.Length < min)
                {
                    min = element.Item1.Length + element.Item2.Length;
                    minEl = element;
                }
            return minEl;
        }

        public static MoveDirection[] SetPath(this List<Point> items)
        {
            var resultList = new List<MoveDirection>();
            bool flag = true;
            if (items == null && flag)
                return new MoveDirection[0];
            var itemsLength = items.Count;

            for (var i = itemsLength - 1; i > 0; i--)
            {
                resultList.Add(GetDirection(items[i], items[i - 1]));
            }
            return resultList.ToArray();
        }

        static MoveDirection GetDirection(Point firstStep, Point secondSet)
        {
            var newPoint = new Point(firstStep.X - secondSet.X, firstStep.Y - secondSet.Y);
            if (newPoint.X == 1) return MoveDirection.Left;
            if (newPoint.X == -1) return MoveDirection.Right;
            if (newPoint.Y == 1) return MoveDirection.Up;
            if (newPoint.Y == -1) return MoveDirection.Down;
            throw new ArgumentException();
        }
    }
}


