﻿namespace GeometryTasks;
public class Vector {
    public double X;
    public double Y;

    public double GetLength() {
        return Geometry.GetLength(this);
    }

    public Vector Add(Vector vector) {
        return Geometry.Add(this, vector);
    }

    public bool Belongs(Segment segment) {
        return Geometry.IsVectorInSegment(this, segment);
    }
}

public class Segment {
    public Vector Begin;
    public Vector End;

    public double GetLength() {
        return Geometry.GetLength(this);
    }

    public bool Contains(Vector vector) {
        return Geometry.IsVectorInSegment(vector, this);
    }
}

public class Geometry {
    public static double GetLength(Vector vector) {
        return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }

    public static Vector Add(Vector vector1, Vector vector2) {
        return new Vector() { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };
    }

    public static double GetLength(Segment segment) {
        return Geometry.GetLength(Geometry.Add(segment.Begin,
            new Vector() { X = -segment.End.X, Y = -segment.End.Y }));
    }

    public static bool IsVectorInSegment(Vector vector, Segment segment) {
        return (((segment.Begin.X >= vector.X && segment.End.X <= vector.X)
            || (segment.Begin.X <= vector.X && segment.End.X >= vector.X))
            && ((segment.Begin.Y >= vector.Y && segment.End.Y <= vector.Y)
            || (segment.Begin.Y <= vector.Y && segment.End.Y >= vector.Y)))
            && ((vector.X - segment.Begin.X) * (segment.End.Y - segment.Begin.Y)
            - (vector.Y - segment.Begin.Y) * (segment.End.X - segment.Begin.X) == 0);
    }
}
