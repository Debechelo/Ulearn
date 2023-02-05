namespace Mazes
{
    public static class SnakeMazeTask {
        public static void MoveOut(Robot robot, int width, int height) {
            for(int i = 0; i < (height - 2) / 2; i++) {
                if(i % 2 == 0)
                    Move(robot, width - 3, Direction.Right);
                else
                    Move(robot, width - 3, Direction.Left);
                Move(robot, 2, Direction.Down);
            }
            if(height % 2 == 1)
                Move(robot, width - 3, Direction.Left);
        }

        static void Move(Robot robot, int stepCount, Mazes.Direction direction) {
            for(int i = 0; i < stepCount; i++)
                robot.MoveTo(direction);
        }
    }
}