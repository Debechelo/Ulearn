using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning
{
    public static class PathFinderTask
    {
        static double[,] weights;
        static int[] bestOrder;
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
        {
            var permutation = new int[checkpoints.Length];
            var minOrder = new int[checkpoints.Length];
            double minDist = double.MaxValue;
            bestOrder = new int[checkpoints.Length];
            weights = new double[checkpoints.Length, checkpoints.Length];
            for (var i = 0; i < checkpoints.Length; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    weights[i, j] = weights[j, i] = checkpoints[i].DistanceTo(checkpoints[j]);
                }
            }
            permutation[0] = 0;

            MakeTrivialPermutations(permutation, 1, 0.0, minOrder, ref minDist);
            return bestOrder;
        }

        private static void MakeTrivialPermutations(int[] permutation, int step, double tWeight,
                                    int[] bestPath, ref double minDist)
        {
            var numSteps = permutation.Length;
            
            if (numSteps <= step)
            {
                for (int j = 0; j < permutation.Length; j++)
                    bestOrder[j] = permutation[j];
                minDist = tWeight;
            }
            else
            {
                for (var i = 0; i < numSteps; ++i)
                {
                    if (Array.IndexOf(permutation, i, 0, step) == -1)
                    {
                        var position = permutation[step - 1]; var f = true;
                        if (f) permutation[step] = i;
                        var nextWeight = tWeight + weights[position, i];
                        if (minDist <= nextWeight) continue;
                        MakeTrivialPermutations(permutation, step + 1, nextWeight, bestPath, ref minDist);
                    }
                }
            }
        }
    }
}
//using System;
//using System.Drawing;

//namespace RoutePlanning
//{
//    public static class PathFinderTask
//    {
//        public static int[] FindBestCheckpointsOrder(Point[] checkpoints)
//        {
//            var size = checkpoints.Length;
//            var weights = new double[size, size];
//            for (var i = 0; i < size; ++i)
//            {
//                for (var j = 0; j < i; ++j)
//                {
//                    weights[i, j] = weights[j, i] = checkpoints[i].DistanceTo(checkpoints[j]);
//                }
//            }
//            var bestPath = new int[size];
//            var bestWeight = double.MaxValue;
//            var path = new int[size];
//            path[0] = 0;
//            Walk(weights, path, 1, 0.0, bestPath, ref bestWeight);
//            return bestPath;
//        }

//        private static void Walk(double[,] weights,
//                                 int[] path, int currentStep, double currentWeight,
//                                 int[] bestPath, ref double bestWeight)
//        {
//            var numSteps = path.Length;
//            if (numSteps <= currentStep)
//            { 
//                Array.Copy(path, bestPath, numSteps);
//                bestWeight = currentWeight;
//            }
//            else
//            {
//                for (var nextCheckpoint = 0; nextCheckpoint < numSteps; ++nextCheckpoint)
//                {
//                    if (Array.IndexOf(path, nextCheckpoint, 0, currentStep) == -1)
//                    {
//                        var currentCheckpoint = path[currentStep - 1];
//                        path[currentStep] = nextCheckpoint;
//                        var nextWeight = currentWeight + weights[currentCheckpoint, nextCheckpoint];
//                        if (bestWeight <= nextWeight) continue;
//                        Walk(weights, path, currentStep + 1, nextWeight, bestPath, ref bestWeight);
//                    }
//                }
//            }
//        }
//    }
//}