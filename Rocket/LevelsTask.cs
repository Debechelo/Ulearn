using System;
using System.Collections.Generic;

namespace func_rocket
{
	public class LevelsTask
	{
		static readonly Physics standardPhysics = new Physics();

		public static Vector Hole = new Vector(500, 100);
		public static Rocket standardRocket = new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI);

		public static IEnumerable<Level> CreateLevels()
		{
			yield return new Level("Zero",
				standardRocket,
				new Vector(600, 200),
				(size, v) => Vector.Zero,
				standardPhysics);
			yield return new Level("Heavy",
				standardRocket,
				new Vector(600, 200),
				(size, v) => new Vector(0, 0.9),
				standardPhysics);
			yield return new Level("Up",
				standardRocket,
				new Vector(700, 500),
				(size, v) => new Vector(0, -300 / (size.Height - v.Y + 300.0)),
				standardPhysics);

			Func<Vector, double, Vector> force = (dv, k) => dv.Normalize() * (k * dv.Length / (dv.Length * dv.Length + 1));
			yield return new Level("WhiteHole",
				standardRocket,
				Hole,
				(size, v) => force(v - Hole, 140),
				standardPhysics);
			var blackHole = 0.5 * (Hole + new Vector(200, 500));
			yield return new Level("BlackHole",
				standardRocket,
				Hole,
				(size, v) => force(blackHole - v, 300),
				standardPhysics);
			yield return new Level("BlackAndWhite",
				standardRocket,
				Hole,
				(size, v) => (force(v - Hole, 140) + force(blackHole - v, 300)) / 2,
				standardPhysics);
		}


	}
}