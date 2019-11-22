using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    static int size = 16;

    public Item[] items = new Item[size];
    int current;

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
}
