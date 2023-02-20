using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation {
    public static class ManipulatorTask {
        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y 
        /// с углом между последним суставом и горизонталью, равному alpha (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double alpha) {
            // Используйте поля Forearm, UpperArm, Palm класса Manipulator
            double wristPosX = x - Math.Cos(alpha) * Manipulator.Palm;
            double wristPosY = y + Math.Sin(Math.PI - alpha) * Manipulator.Palm;
            double elbow = TriangleTask.GetABAngle(Manipulator.UpperArm,
                Manipulator.Forearm,
                Math.Sqrt(wristPosX * wristPosX + wristPosY * wristPosY));
            double shoulder = TriangleTask.GetABAngle(Manipulator.UpperArm,
                Math.Sqrt(wristPosX * wristPosX + wristPosY * wristPosY),
                Manipulator.Forearm);
            shoulder += Math.Atan2(wristPosY, wristPosX);
            double wrist = -alpha - shoulder - elbow;

            //return new[] { double.NaN, double.NaN, double.NaN };
            return new[] { shoulder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests {
        [Test]
        public void TestMoveManipulatorTo() {
            for(int i = 0; i < 100; i++) {
                var rnd = new Random();
                var x = rnd.NextDouble() * 10;
                var y = rnd.NextDouble() * 10;
                var alpha = rnd.NextDouble() * 10;
                var result = ManipulatorTask.MoveManipulatorTo(x, y, alpha);
                var position = AnglesToCoordinatesTask.GetJointPositions(result[0],
                                                                         result[1], result[2]);
                Assert.AreEqual(x, position[2].X, 10e-6);
                Assert.AreEqual(y, position[2].Y, 10e-6);
            }
        }
    }
}