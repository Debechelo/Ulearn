using System;

namespace Mazes {
    public static class DiagonalMazeTask {
        public static void MoveOut(Robot robot, int width, int height) {
            int length = Math.Max((width - 2) / (height - 2), (height - 2) / (width - 2));
            int iter = Math.Min(height - 2, width - 2);
            Mazes.Direction direction1 = Direction.Right;
            Mazes.Direction direction2 = Direction.Down;
            if(height > width) {
                direction1 = Direction.Down;
                direction2 = Direction.Right;
            }
            for(int i = 0; i < iter; i++) {
                Move(robot, length, direction1);
                if(i != iter - 1)
                    Move(robot, 1, direction2);
            }
        }

        static void Move(Robot robot, int stepCount, Mazes.Direction direction) {
            for(int i = 0; i < stepCount; i++)
                robot.MoveTo(direction);
        }
    }
}