using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		private int memoryPointer;
		private int instructionPointer;
		private byte[] memory;
		string instructions;
		private Dictionary<char, Action<IVirtualMachine>> comand;


		public VirtualMachine(string program, int memorySize)
		{
			instructions = program;
			memory = new byte[memorySize];
			comand = new Dictionary<char, Action<IVirtualMachine>>(memorySize);
		}

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			comand.Add(symbol, execute);
		}


		public string Instructions { get { return instructions; } }
		public int InstructionPointer { get { return instructionPointer; } set { instructionPointer = value; } }
		public byte[] Memory { get { return memory; } }
		public int MemoryPointer { get { return memoryPointer; } set { memoryPointer = value; } }
		public void Run()
		{
			char ch;
			while (instructionPointer < instructions.Length)
			{
				ch = instructions[instructionPointer];
				if (comand.ContainsKey(ch))
					comand[ch](this);
				instructionPointer++;
			}
		}
	}
}