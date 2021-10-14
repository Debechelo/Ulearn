namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			for (int i = 0; i < height / 4; i++)
			{
				MoveRight(robot, width - 3);
				TwoStepsDown(robot);
				MoveLeft(robot, width - 3);
				if (i < height / 4 - 1)
					TwoStepsDown(robot);
			}
		}

		public static void MoveRight(Robot robot, int step)
		{
			for (int i = 0; i < step; i++)
			{
				robot.MoveTo(Direction.Right);
			}
		}

		public static void MoveLeft(Robot robot, int step)
		{
			for (int i = 0; i < step; i++)
			{
				robot.MoveTo(Direction.Left);
			}
		}

		public static void TwoStepsDown(Robot robot)
		{
			robot.MoveTo(Direction.Down);
			robot.MoveTo(Direction.Down);
		}
	}
}