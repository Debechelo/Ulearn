using System;

namespace func_rocket
{
    public class ControlTask
    {
        public static double AngleTurn;

        public static Turn ControlRocket(Rocket rocket, Vector target)
        {
            Vector distance = new Vector(target.X - rocket.Location.X, target.Y - rocket.Location.Y);
            if (0.5 > Math.Abs(distance.Angle - rocket.Direction)
                || 0.5 > Math.Abs(distance.Angle - rocket.Velocity.Angle))
            {
                AngleTurn = (distance.Angle - rocket.Direction
                             + distance.Angle - rocket.Velocity.Angle) / 2;
            }
            else AngleTurn = distance.Angle - rocket.Direction;
            if (AngleTurn < 0)
                return Turn.Left;
            return AngleTurn > 0 ? Turn.Right : Turn.None;
        }
    }
}