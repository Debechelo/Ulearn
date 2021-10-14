//using System;

//namespace GeometryTasks
//{
//	class Vector
//	{
//		public double X;
//		public double Y;

//		public Vector(double x, double y)
//		{
//			X = x;
//			Y = y;
//		}

//		public Vector()
//		{
//			X = 0;
//			Y = 0;
//		}
//	}

//	class Geometry
//	{
//		public static double GetLength(Vector v)
//		{
//			return Math.Sqrt(v.X * v.X + v.Y * v.Y);
//		}

//		public static Vector Add(Vector v1, Vector v2)
//		{
//			return new Vector(v1.X + v2.X, v1.Y + v2.Y); ;
//		}
//	}
//}

//using System;

//namespace GeometryTasks
//{
//	class Vector
//	{
//		public double X;
//		public double Y;

//		public Vector(double x, double y)
//		{
//			X = x;
//			Y = y;
//		}

//		public Vector()
//		{
//			X = 0;
//			Y = 0;
//		}
//	}

//	class Geometry
//	{
//		public static double GetLength(Vector v)
//		{
//			return Math.Sqrt(v.X * v.X + v.Y * v.Y);
//		}

//		public static Vector Add(Vector v1, Vector v2)
//		{
//			return new Vector(v1.X + v2.X, v1.Y + v2.Y); ;
//		}

//		public static double GetLength(Segment segment)
//		{
//			double x = Math.Abs(segment.Begin.X - segment.End.X);
//			double y = Math.Abs(segment.Begin.Y - segment.End.Y);
//			return Math.Sqrt(x * x + y * y);
//		}

//		public static bool IsVectorInSegment(Vector vector, Segment segment)
//		{
//			var dx1 = segment.Begin.X - segment.End.X;
//			var dy1 = segment.Begin.Y - segment.End.Y;

//			var dx = vector.X - segment.End.X;
//			var dy = vector.Y - segment.End.Y;

//			return segment.Begin.X <= vector.X && segment.End.X >= vector.X
//				&& segment.Begin.Y <= vector.Y && segment.End.Y >= vector.Y
//				&& (dx1 * dy - dx * dy1) == 0;
//		}
//	}

//	class Segment
//	{
//		public Vector Begin;
//		public Vector End;

//		public Segment(Vector begin, Vector end)
//		{
//			Begin = begin;
//			End = end;
//		}

//		public Segment()
//		{
//			Begin = new Vector();
//			End = new Vector();
//		}
//	}
//}

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GeometryTasks
{
	class Vector
	{
		public double X;
		public double Y;

		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public Vector()
		{
			X = 0;
			Y = 0;
		}

		public double GetLength()
		{
			return Geometry.GetLength(this);
		}

		public Vector Add(Vector vector)
		{
			return Geometry.Add(this, vector); ;
		}

		public bool Belongs(Segment segment)
		{
			return Geometry.IsVectorInSegment(this, segment);
		}
	}

	class Geometry
	{
		public static double GetLength(Vector v)
		{
			return Math.Sqrt(v.X * v.X + v.Y * v.Y);
		}

		public static Vector Add(Vector v1, Vector v2)
		{
			return new Vector(v1.X + v2.X, v1.Y + v2.Y); ;
		}

		public static double GetLength(Segment segment)
		{
			double x = Math.Abs(segment.Begin.X - segment.End.X);
			double y = Math.Abs(segment.Begin.Y - segment.End.Y);
			return Math.Sqrt(x * x + y * y);
		}

		public static bool IsVectorInSegment(Vector vector, Segment segment)
		{
			var dx1 = segment.Begin.X - segment.End.X;
			var dy1 = segment.Begin.Y - segment.End.Y;

			var dx = vector.X - segment.End.X;
			var dy = vector.Y - segment.End.Y;

			return segment.Begin.X <= vector.X && segment.End.X >= vector.X
				&& segment.Begin.Y <= vector.Y && segment.End.Y >= vector.Y
				&& (dx1 * dy - dx * dy1) == 0;
		}
	}

	class Segment
	{
		public Vector Begin;
		public Vector End;

		public Segment(Vector begin, Vector end)
		{
			Begin = begin;
			End = end;
		}

		public Segment()
		{
			Begin = new Vector();
			End = new Vector();
		}

		public double GetLength()
		{
			return Geometry.GetLength(this);
		}

		public bool Contains(Vector vector)
		{
			return Geometry.IsVectorInSegment(vector, this);
		}
	}
}