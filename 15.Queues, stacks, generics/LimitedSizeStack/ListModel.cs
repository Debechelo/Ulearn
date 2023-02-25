using System;
using System.Collections.Generic;

namespace LimitedSizeStack;

public class Action<TItem> {
    public bool AddFlag { get; set; }
    public int Index { get; set; }
    public TItem Value { get; set; }
}
public class ListModel<TItem> {
    public List<TItem> Items { get; }
    public LimitedSizeStack<Action<TItem>> LimitStack { get; set; }
    public int UndoLimit { get; }

    public ListModel(int undoLimit)
        : this(new List<TItem>(), undoLimit) {
        //LimitStack = new LimitedSizeStack<Action<TItem>>(undoLimit);
    }

    public ListModel(List<TItem> items, int undoLimit) {
        Items = items;
        LimitStack = new LimitedSizeStack<Action<TItem>>(undoLimit);
        UndoLimit = undoLimit;
    }

    public void AddItem(TItem item) {
        LimitStack.Push(new Action<TItem>() { AddFlag = true });
        Items.Add(item);
    }

    public void RemoveItem(int index) {
        LimitStack.Push(new Action<TItem>() { 
            AddFlag = false,
            Index = index, 
            Value = Items[index] });

        Items.RemoveAt(index);
    }

    public bool CanUndo() {
        return LimitStack.Count > 0;
    }

    public void Undo() {
        if(!CanUndo())
            return;
        var action = LimitStack.Pop();
        if(action.AddFlag)
            Items.RemoveAt(Items.Count - 1);
        else
            Items.Insert(action.Index, action.Value);
    }
}