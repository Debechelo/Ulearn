using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace func.brainfuck
{
	public class BrainfuckBasicCommands
	{
		public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
		{
			Encoding enc = Encoding.ASCII;
			vm.RegisterCommand('.', b => { write((char)vm.Memory[vm.MemoryPointer]); });
			vm.RegisterCommand('+', b => {
				int t = vm.Memory[vm.MemoryPointer];
				if (++t == 256)
					vm.Memory[vm.MemoryPointer] = 0;
				else vm.Memory[vm.MemoryPointer]++;
			});
			vm.RegisterCommand('-', b => {
				int t = vm.Memory[vm.MemoryPointer];
				if (--t == -1)
					vm.Memory[vm.MemoryPointer] = 255;
				else vm.Memory[vm.MemoryPointer] = (byte)t;
			});
			vm.RegisterCommand(',', b => { vm.Memory[vm.MemoryPointer] = (byte)read(); });
			vm.RegisterCommand('>', b => {
				if (vm.MemoryPointer + 1 < vm.Memory.Length)
					vm.MemoryPointer++;
				else vm.MemoryPointer = 0;
			});
			vm.RegisterCommand('<', b => {
				if (vm.MemoryPointer - 1 >= 0)
					vm.MemoryPointer--;
				else vm.MemoryPointer = vm.Memory.Length - 1;
			});

			char[] symbol = new char[] { 'Q','W','E','R','T','Y','U','I','O','P','A','S',
				'D','F','G','H','J','K','L','Z','X','C','V','B','N','M','q','w','e','r',
				't','y','u','i','o','p','a','s','d','f','g','h','j','k','l','z','x','c',
				'v','b','n','m','1','2','3','4','5','6','7','8','9','0'};
			foreach (char ch in symbol)
			{
				vm.RegisterCommand(ch, b => { vm.Memory[vm.MemoryPointer] = (byte)ch; });
			}
		}
	}
}