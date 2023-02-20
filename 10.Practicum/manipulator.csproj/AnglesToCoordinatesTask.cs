using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbow_new = elbow + shoulder + Math.PI;
            var wrist_new = elbow + shoulder + wrist;

            var elbowPos = new PointF((float)(Manipulator.UpperArm * Math.Cos(shoulder)),
                                      (float)(Manipulator.UpperArm * Math.Sin(shoulder)));
            var wristPos = new PointF((float)(elbowPos.X + Manipulator.Forearm * Math.Cos(elbow_new)),
                                      (float)(elbowPos.Y + Manipulator.Forearm * Math.Sin(elbow_new)));
            var palmEndPos = new PointF((float)(wristPos.X + Manipulator.Palm * Math.Cos(wrist_new)),
                                        (float)(wristPos.Y + Manipulator.Palm * Math.Sin(wrist_new)));
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        // Доработайте эти тесты!
        // С помощью строчки TestCase можно добавлять новые тестовые данные.
        // Аргументы TestCase превратятся в аргументы метода.
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        [TestCase(Math.PI / 2, Math.PI, Math.PI, 0, Manipulator.Forearm + Manipulator.UpperArm + Manipulator.Palm)]
        [TestCase(-Math.PI / 2, Math.PI / 2, Math.PI, -Manipulator.Forearm - Manipulator.Palm, -Manipulator.UpperArm)]
        [TestCase(0, 0, 0, -Manipulator.Forearm + Manipulator.UpperArm + Manipulator.Palm, 0)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            //Assert.Fail("TODO: проверить, что расстояния между суставами равны длинам сегментов манипулятора!");
        }
    }
}