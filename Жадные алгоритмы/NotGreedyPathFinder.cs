using System.Collections.Generic;
using System.Drawing;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;
using System.Linq;
using System;

namespace Greedy
{
    public class NotGreedyPathFinder : IPathFinder
    {
        public List<Point> FindPathToCompleteGoal(State state)
        {
            DijkstraPathFinder dijkstraPathFinder = new DijkstraPathFinder();
            Stack<PathWithCost> pathsThroughAllChests = new Stack<PathWithCost>();
            HashSet<Point> unusedChests = new HashSet<Point>(state.Chests);
            Dictionary<(Point start, Point end), PathWithCost> dictionaryOfPaths = new Dictionary<(Point start, Point end), PathWithCost>();
            List<PathWithCost> bestPath = null;

            foreach (var chest in state.Chests)
            {
                var result = FindThePathToTheFirstChest(unusedChests, state.Position, state,
                    chest, 0, pathsThroughAllChests, dijkstraPathFinder, dictionaryOfPaths,  ref bestPath);
                if (result != null)
                    return result;
            }

            if (bestPath != null)
                return PaveTheWay(bestPath);
            return new List<Point>();
        }

        List<Point> FindThePathToTheFirstChest(HashSet<Point> unusedChests, Point previousNode, State state, 
            Point chest, int price,  Stack<PathWithCost> pathsThroughAllChests,
            DijkstraPathFinder dijkstraPathFinder,
            Dictionary<(Point start, Point end), PathWithCost> dictionaryOfPaths,
            ref List<PathWithCost> bestPath)
        {
            PathWithCost pathToCurrentChest = PathToCell(previousNode, chest, state, dictionaryOfPaths,  dijkstraPathFinder);
            if (pathToCurrentChest == null)
                return null;
            unusedChests.Remove(chest);
            price += pathToCurrentChest.Cost;
            bool flag = false;
            pathsThroughAllChests.Push(pathToCurrentChest);
            if (price <= state.Energy && unusedChests.Count > 0 && !flag)
                foreach (var newCurrentChest in unusedChests.ToList())
                {
                    var result = FindThePathToTheFirstChest(unusedChests, chest, state, newCurrentChest,
                        price,pathsThroughAllChests, dijkstraPathFinder, dictionaryOfPaths,  ref bestPath);
                    if (result != null)
                        return result;
                }
            else
            {
                if (price <= state.Energy && unusedChests.Count == 0)
                    return PaveTheWay(pathsThroughAllChests.ToList());
                else
                {
                    unusedChests.Add(chest);
                    pathsThroughAllChests.Pop();
                    CheckTheBestWay(pathsThroughAllChests,ref bestPath);
                    return null;
                }
            }
            unusedChests.Add(chest);
            pathsThroughAllChests.Pop();
            return null;
        }

        private void CheckTheBestWay(Stack<PathWithCost> pathsThroughAllChests,ref List<PathWithCost> bestPath )
        {
            if (bestPath == null || bestPath.Count < pathsThroughAllChests.Count)
                bestPath = pathsThroughAllChests.ToList();
        }

        private List<Point> PaveTheWay(List<PathWithCost> pathsThroughAllChests)
        {
            var resultPath = new List<Point>();
            for (int i = pathsThroughAllChests.Count - 1; i >= 0; i--)
            {
                var path = pathsThroughAllChests[i];
                for (int j = 1; j < path.Path.Count; j++)
                    resultPath.Add(path.Path[j]);
            }
            return resultPath;
        }

        private PathWithCost PathToCell(Point previousNode, Point chest, State state,
            Dictionary<(Point start, Point end), PathWithCost> dictionaryOfPaths, DijkstraPathFinder dijkstraPathFinder)
        {
            if (dictionaryOfPaths.TryGetValue((previousNode, chest), out var path))
                return path;
            path = dijkstraPathFinder.GetPathsByDijkstra(state, previousNode, new[] { chest }).FirstOrDefault();
            dictionaryOfPaths[(previousNode, chest)] = path;
            return path;
        }
    }
}