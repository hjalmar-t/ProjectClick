using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Item : ScriptableObject {

    //public class Combination {
    //    public Item combineWith;
    //    public Item combineTo;
    //    public bool destroyOnCombine;

    //    Combination(Item item1, Item item2, bool destroy) {
    //        combineWith = item1;
    //        combineTo = item2;
    //        destroyOnCombine = destroy;
    //    }
    //}

    public string itemName;
    public Sprite itemImage;
    public string description;
    public string descriptionLong;

    //[SerializeField]
    //public List<Combination> combinations = new List<Combination>();
    //[SerializeField]
    //public Combination combination;

    public Item combineWith;
    public Item combineTo;
    public bool destroyOnCombine;

    public string GetItemName() { return itemName; }
    public Sprite GetItemImage() { return itemImage; }
    public string GetDescription() { return description; }
    public string GetDescriptionLong() { return description; }

}

//[Serializable]
//public class Combination
//{
//    public Item combineWith;
//    public Item combineTo;
//    public bool destroyOnCombine;

//    Combination(Item item1, Item item2, bool destroy) {
//        combineWith = item1;
//        combineTo = item2;
//        destroyOnCombine = destroy;
//    }
//}
