using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{

    //class Page
    //{
    //    Item[] items = new Item[size];
    //}

    public static int size = 100;

    public int current = -1;
    public Item[] items = new Item[size];

    public void SetCurrent(int i) { current = i; }
    public int GetCurrent() { return current; }

    public void Add(Item addendum) {
        for(int i = 0; i < items.Length; i++) {
            if(items[i] == null) {
                items[i] = addendum;
                return;
            }
        }
    }

    public Item GetAtIndex(int index) {
        return items[index];
    }

    public void Copy(Inventory i) {
        i.items.CopyTo(this.items, 0);
    }

    public void Swap(int i) {
        if(items[current] == null) return;

        Item temp = items[i];
        items[i] = items[current];
        items[current] = temp;
    }
}
