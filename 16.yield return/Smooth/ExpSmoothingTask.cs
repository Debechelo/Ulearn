using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace yield;

public static class ExpSmoothingTask
{
	public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
	{
        double sum = 0;
        var e = data.GetEnumerator();

        e.MoveNext();
        if(e.Current != null) {
            sum = e.Current.OriginalY;
            yield return e.Current.WithExpSmoothedY(sum);
        }
        while(e.MoveNext()) { 
            sum += alpha * (e.Current.OriginalY - sum);
            yield return e.Current.WithExpSmoothedY(sum);
        }
    }
}
