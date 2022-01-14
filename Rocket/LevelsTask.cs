using System;
using System.Collections.Generic;

namespace func_rocket
{
	public class LevelsTask
	{
		static readonly Physics NormPhysics = new Physics();

		public static Vector Hole = new Vector(600, 200);
		public static Rocket NormRocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);

		public static IEnumerable<Level> CreateLevels()
		{
			yield return new Level("Zero",
				NormRocket,
				Hole,
				(size, v) => Vector.Zero,
				NormPhysics);
			yield return new Level("Heavy",
				NormRocket,
				Hole,
				(size, v) => new Vector(0, 0.9),
				NormPhysics);
			yield return new Level("Up",
				NormRocket,
				new Vector(700, 500),
				(size, v) => new Vector(0, -300 / (size.Height - v.Y + 300.0)),
				NormPhysics);

			Func<Vector, double, Vector> force = (dv, k) => dv.Normalize() * (k * dv.Length / (dv.Length * dv.Length + 1));
			yield return new Level("WhiteHole",
				NormRocket,
				Hole,
				(size, v) => force(v - Hole, 140),
				NormPhysics);
			var blackHole = 0.5 * (Hole + new Vector(200, 500));
			yield return new Level("BlackHole",
				NormRocket,
				Hole,
				(size, v) => force(blackHole - v, 300),
				NormPhysics);
			yield return new Level("BlackAndWhite",
				NormRocket,
				Hole,
				(size, v) => (force(v - Hole, 140) + force(blackHole - v, 300)) / 2,
				NormPhysics);
		}
	}
}