using System;

namespace func_rocket
{
    public class ControlTask
    {
        public static double AngleTurn;

        public static Turn ControlRocket(Rocket rocket, Vector target)
        {
            Vector remainDistance = new Vector(target.X - rocket.Location.X, target.Y - rocket.Location.Y);

            if (0.5 > Math.Abs(remainDistance.Angle - rocket.Direction)
                || 0.5 > Math.Abs(remainDistance.Angle - rocket.Velocity.Angle))
            {
                AngleTurn = (remainDistance.Angle - rocket.Direction
                             + remainDistance.Angle - rocket.Velocity.Angle) / 2;
            }
            else AngleTurn = remainDistance.Angle - rocket.Direction;
            if (AngleTurn < 0)
                return Turn.Left;
            return AngleTurn < 0 ? Turn.None : Turn.Right;
        }
    }
}