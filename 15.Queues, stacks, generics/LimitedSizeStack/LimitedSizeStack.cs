using NUnit.Framework.Constraints;
using System;

namespace LimitedSizeStack;

public class Node<T> {
	public T Value { get; set; }
	public Node<T> Next { get; set; }
    public Node<T> Prev { get; set; }

	public Node(T value) {
		Value = value;
	}
}

public class LimitedSizeStack<T> {
    public int Count { get; set; } = 0;
    int Limit { get; set; }
    Node<T> Head { get; set; }
    Node<T> Tail { get; set; }

    public LimitedSizeStack(int undoLimit) {
        Limit = undoLimit;
    }

    public void Push(T item) {
        Node<T> node = new Node<T>(item);
		if(Limit > 0) {
			if(Count == 0) {
				Head = node;
				Tail = node;
				Count++;
			} else if(Count < Limit) {
				Tail.Next = node;
				node.Prev = Tail;
				Tail = node;
				Count++;
			} else if(Count == Limit) {
				Tail.Next = node;
				node.Prev = Tail;
				Tail = node;
				Head = Head.Next;
				Head.Prev = null;
			}
		}
	}

	public T Pop() {
		if(Count == 0)
			return default(T);
		T val = Tail.Value;
		if(Count == 1) {
			Head = null;
			Tail = null;
		} else {
			Tail = Tail.Prev;
			Tail.Next = null;
		}
        Count--;
        return val;
	}

	//public int Count => throw new NotImplementedException();
}