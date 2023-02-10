using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoutePlanning {
	public static class PathFinderTask {

        static double[,] weightArray;
        public static int[] FindBestCheckpointsOrder(Point[] checkpoints) { 
            int[] result = new int[checkpoints.Length];
            double minWeight = double.MaxValue;
            weightArray = MakeWeightTable(checkpoints);
            double weight = 0;
            MakeTrivialPermutation(new int[checkpoints.Length], 1, result, weight, ref minWeight);

            return result;
        }

        private static double[,] MakeWeightTable(Point[] checkpoints) {
            double[,] weightArray = new double[checkpoints.Length, checkpoints.Length];
            for(int i = 0; i < checkpoints.Length; i++) {
                for(int j = i + 1; j < checkpoints.Length; j++) {
                    double weight = getWeight(checkpoints[i], checkpoints[j]);
                    weightArray[i, j] = weight;
                    weightArray[j, i] = weight;
                }    
            }

            return weightArray;
        }

        private static double getWeight(Point point1, Point point2) {
            return Math.Sqrt((point1.X  - point2.X) * (point1.X - point2.X) 
                + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

		private static void MakeTrivialPermutation(int[] permutation, int position,
            int[] result, double weight, ref double minWeight) {
            if(position == permutation.Length) {
                if(minWeight > weight) {
                    minWeight = weight;
                    permutation.CopyTo(result, 0);
                }
                return;
            }

            for(int i = 1; i < permutation.Length; i++) {
                var index = Array.IndexOf(permutation, i, 0, position);
                if(index == -1) {
                    permutation[position] = i;
                    weight += weightArray[permutation[position - 1], permutation[position]];
                    if(weight > minWeight)
                        return;
                    MakeTrivialPermutation(permutation, position + 1, result, weight, ref minWeight);
                    weight -= weightArray[permutation[position - 1], permutation[position]];
                }
            }
        }
    }
}