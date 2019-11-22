using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;

    List<string> combineWith = new List<string>();
    List<string> combineTo = new List<string>();

    public Sprite GetItemImage() { return itemImage; }

    bool canCombine() {
        if(combineWith[0] != null) return true;
        return false;
    }

}
