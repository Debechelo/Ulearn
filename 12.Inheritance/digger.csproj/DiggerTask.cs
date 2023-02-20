using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digger
{
    //Напишите здесь классы Player, Terrain и другие.

    public class Player: ICreature {
        public CreatureCommand Act(int x, int y) {
            if(Game.KeyPressed == Keys.Down && y + 1 < Game.MapHeight && !(Game.Map[x, y + 1] is Sack))
                return new CreatureCommand() {DeltaX = 0, DeltaY = 1} ;
            if(Game.KeyPressed == Keys.Up && y - 1 > -1 && !(Game.Map[x, y - 1] is Sack))
                return new CreatureCommand() { DeltaX = 0, DeltaY = -1 };
            if(Game.KeyPressed == Keys.Right && x + 1 < Game.MapWidth && !(Game.Map[x + 1, y] is Sack))
                return new CreatureCommand() { DeltaX = 1, DeltaY = 0 };
            if(Game.KeyPressed == Keys.Left && x - 1 > -1 && !(Game.Map[x - 1, y] is Sack))
                return new CreatureCommand() { DeltaX = -1, DeltaY = 0 };
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) {
            return conflictedObject is Sack || conflictedObject is Monster;
        }

        public int GetDrawingPriority() {
            return 5;
        }

        public string GetImageFileName() {
            return "Digger.png";
        }
    }

    class Monster: ICreature {
        public bool IsEmptyWay(int x, int y) {
            return Game.Map[x, y] == null || Game.Map[x, y] is Gold || Game.Map[x, y] is Player
                && !(Game.Map[x, y] is Monster);
        }

        public (int, int) GetPosition() {
            for(int i = 0; i < Game.MapWidth; i++)
                for(int j = 0; j < Game.MapHeight; j++) {
                    if(Game.Map[i, j] != null && Game.Map[i, j] is Player) {
                        return (i, j);
                    }
                }
            return (-1, -1);
        }

        public CreatureCommand Act(int x, int y) {
            (int, int) position = GetPosition();
            if(position.Item1 != -1) {
                if(position.Item1 < x && IsEmptyWay(x - 1, y))
                    return new CreatureCommand() { DeltaX = -1, DeltaY = 0, TransformTo = this };
                if(position.Item1 > x && IsEmptyWay(x + 1, y))
                    return new CreatureCommand() { DeltaX = 1, DeltaY = 0, TransformTo = this };
                if(position.Item2 < y && IsEmptyWay(x, y - 1))
                    return new CreatureCommand() { DeltaX = 0, DeltaY = -1, TransformTo = this };
                if(position.Item2 > y && IsEmptyWay(x, y + 1))
                    return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = this };
            }
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = this };
        }

        public bool DeadInConflict(ICreature conflictedObject) {
            return conflictedObject is Sack || conflictedObject is Monster;
            ;
        }

        public int GetDrawingPriority() {
            return 1;
        }

        public string GetImageFileName() {
            return "Monster.png";
        }
    }

    public class Gold: ICreature {
        public CreatureCommand Act(int x, int y) {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject){
            if(conflictedObject is Player) {
                Game.Scores += 10;
                return true;
            }
            return conflictedObject is Monster;
        }

        public int GetDrawingPriority() {
            return 3;
        }

        public string GetImageFileName() {
            return "Gold.png";
        }
    }

    public class Sack: ICreature {
        int k = 0;
        public CreatureCommand Act(int x, int y) {
            if((y + 1 < Game.MapHeight && Game.Map[x, y + 1] is null) 
                || (y + 1 < Game.MapHeight && k > 0 && (Game.Map[x, y + 1] is Player
                 || Game.Map[x, y + 1] is Monster))) {
                k++;
                return new CreatureCommand() { DeltaY = 1 };
            }
            if(k < 2)
                k = 0;
            else {
                return new CreatureCommand() { TransformTo = new Gold()};
            }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) {
            return false;
        }

        public int GetDrawingPriority() {
            return 0;
        }

        public string GetImageFileName() {
            return "Sack.png";
        }
    }

    public class Terrain: ICreature {
        public CreatureCommand Act(int x, int y) {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) {
            return conflictedObject is Player || conflictedObject is Sack;       
        }

        public int GetDrawingPriority() {
            return 0;
        }

        public string GetImageFileName() {
            return "Terrain.png";
        }
    }
}
