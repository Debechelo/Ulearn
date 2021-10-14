using System;
using System.Collections.Generic;

namespace func.brainfuck
{
    public class BrainfuckLoopCommands
    {
        public static Tuple<Dictionary<int, int>, Dictionary<int, int>> Loops;


        public static void RegisterTo(IVirtualMachine vm)
        {
            Loops = new Tuple<Dictionary<int, int>, Dictionary<int, int>>(new Dictionary<int, int>(), new Dictionary<int, int>());
            FindLoops(vm);
            vm.RegisterCommand('[', b => {
                if (vm.Memory[vm.MemoryPointer] == 0 && Loops.Item1.ContainsKey(vm.InstructionPointer))
                {
                    vm.InstructionPointer = Loops.Item1[vm.InstructionPointer];
                }
            });
            vm.RegisterCommand(']', b => {
                if (vm.Memory[vm.MemoryPointer] != 0 && Loops.Item2.ContainsKey(vm.InstructionPointer))
                    vm.InstructionPointer = Loops.Item2[vm.InstructionPointer];
            });
        }

        static void FindLoops(IVirtualMachine vm)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < vm.Instructions.Length; i++)
            {
                if (vm.Instructions[i] == '[')
                    stack.Push(i);
                else if (vm.Instructions[i] == ']')
                {
                    var begin = stack.Pop();
                    Loops.Item1.Add(begin, i);
                    Loops.Item2.Add(i, begin);
                }
            }
        }
    }
}