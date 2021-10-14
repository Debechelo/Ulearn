namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			if (width < height)
				MoveDiagonal(robot, width - 2, height - 2, true);
			else MoveDiagonal(robot, height - 2, width - 2, false);
		}

		public static void NStepMove(Robot robot, int n, bool direction)
		{
			for (int i = 0; i < n; i++)
				if(direction)
					robot.MoveTo(Direction.Down);
				else robot.MoveTo(Direction.Right);
		}

		public static void MoveDiagonal(Robot robot, int width, int height, bool direction)
		{
			for (int i = 0; i < width; i++){
					NStepMove(robot, height / width, direction);
				if (i < width - 1)
					if (direction)
						robot.MoveTo(Direction.Right);
					else robot.MoveTo(Direction.Down);
			}
		}
	}
}