using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Entity
{
    public Item thisItem;
    public SaveGame save;

    public override void Interract() {
        if(!activated) {
            activated = true;

            save.currentInventory.Add(thisItem);
            Debug.Log(thisItem.itemName + " collected.");
            this.gameObject.SetActive(false);
        }

    }
}
