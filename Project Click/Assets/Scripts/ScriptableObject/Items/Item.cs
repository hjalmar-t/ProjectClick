using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public string description;
    public string descriptionLong;


    List<string> combineWith = new List<string>();
    List<string> combineTo = new List<string>();

    public string GetItemName() { return itemName; }
    public Sprite GetItemImage() { return itemImage; }
    public string GetDescription() { return description; }
    public string GetDescriptionLong() { return description; }


    bool canCombine() {
        if(combineWith[0] != null) return true;
        return false;
    }

}
