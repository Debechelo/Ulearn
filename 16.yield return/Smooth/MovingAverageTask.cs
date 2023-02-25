using System.Collections.Generic;

namespace yield;

public static class MovingAverageTask
{
    public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
        Queue<double> queue = new Queue<double>();
        int k = 0;
        double pSum = 0;
        foreach(var element in data) {
            if(k != windowWidth) { 
                k++;
            } else { 
                pSum -= queue.Dequeue(); 
            }
            queue.Enqueue(element.OriginalY);
            pSum += element.OriginalY;
            yield return element.WithAvgSmoothedY(pSum / k);
        }
        //return data;
    }
}