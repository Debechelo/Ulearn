using System;
using System.Collections.Generic;

namespace Clones {
    public class Node<T> {
        public Node(T data) {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class Stack<T> {
        Node<T> head;
        int count;

        public bool IsEmpty { get { return count == 0; } }
        public int Count { get { return count; } }

        public void Push(T item) {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }

        public T Pop() {
            if(IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public bool Contains(T element) {
            Node<T> node = head;
            while(node != null) {
                if(node.Data.Equals(element))
                    return true;
                node = node.Next;
            }
            return false;
        }

        public object Clone() {
            Stack<T> stack = new Stack<T>();
            stack.head = this.head;
            stack.count = this.count;
            return stack;
        }
    }

    public class Clone {
        public Stack<string> Program;
        public Stack<string> UndoProgram;

        public Clone() {
            Program = new Stack<string>();
            UndoProgram = new Stack<string>();
        }
    }

    public class CloneVersionSystem: ICloneVersionSystem {
        public List<Clone> Clones = new List<Clone>();

        public string Execute(string query) {
            string[] comand = query.Split(' ');
            int num = int.Parse(comand[1]);
            if(num > Clones.Count) { Clones.Add(new Clone()); }
            switch(comand[0]) {
                case "learn":
                    Clones[num - 1].Program.Push(comand[2]);
                    return null;
                case "rollback":
                    Rollback(num);
                    return null;
                case "relearn":
                    Relearn(num);
                    return null;
                case "clone":
                    Copy(num);
                    return null;
                case "check":
                    return Check(num);
            }
            return null;
        }

        public void Rollback(int num) {
            if(!Clones[num - 1].Program.IsEmpty)
                Clones[num - 1].UndoProgram.Push(Clones[num - 1].Program.Pop());
        }

        public void Relearn(int num) {
            if(!Clones[num - 1].UndoProgram.IsEmpty)
                Clones[num - 1].Program.Push(Clones[num - 1].UndoProgram.Pop());
        }

        public void Copy(int num) {
            Clone newclone = new Clone();
            newclone.Program = (Stack<string>)Clones[num - 1].Program.Clone();
            newclone.UndoProgram = (Stack<string>)Clones[num - 1].UndoProgram.Clone();
            Clones.Add(newclone);
        }

        public string Check(int num) {
            if(Clones[num - 1].Program.IsEmpty)
                return "basic";
            string prog = Clones[num - 1].Program.Pop();
            Clones[num - 1].Program.Push(prog);
            return prog;
        }
    }
}