using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for entities that require an item to be used on them.
/// </summary>
/// <remarks>
/// Not intended for use as it is. Inherit this class to use its features.
/// </remarks>
public class ItemUser : Entity
{
    public Item correctItem;

    protected virtual void OnItemUse() {
        Debug.LogWarning("Error: " + this.name + " called the default ITEMUSER interraction method instead of the child specific one.");
    }

    public override void Interract() {
        // Set up references to the player inventory and the current item. Return if there is no current item.
        Inventory inv = save.currentInventory;
        if(inv.GetCurrent() == -1) return;
        Item current = inv.items[inv.current];
        // Call the child specific method, if the inventory is in the correct state and the correct item has been selected.
        if(inv.state == Inventory.State.use && current == correctItem) {
            Debug.Log(current.name + " has been USED on " + gameObject.name);
            OnItemUse();
        }
    }
}
