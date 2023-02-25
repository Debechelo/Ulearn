using System.Collections.Generic;

namespace yield;

public static class MovingMaxTask
{
	public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
	{
		LinkedList<(double, int)> linkedList= new LinkedList<(double, int)>();

		var e = data.GetEnumerator();
		e.MoveNext();
		int k = 0;
        if(e.Current != null) {
			linkedList.AddLast((e.Current.OriginalY, k));
            yield return e.Current.WithMaxY(e.Current.OriginalY);
        }

		while(e.MoveNext()) {
			while(linkedList.Count > 0 && linkedList.Last.Value.Item1 <= e.Current.OriginalY) {
				linkedList.RemoveLast();
			}
            k++;
            linkedList.AddLast((e.Current.OriginalY, k));

			if(linkedList.First.Value.Item2 <= k - windowWidth) {
				linkedList.RemoveFirst();
			}
            yield return e.Current.WithMaxY(linkedList.First.Value.Item1);
        }
	}
}