using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnItemUse : ItemUser
{
    public GameObject toEnable;
    public bool destroyOnUse;
    
    protected override void OnItemUse() {
        if(destroyOnUse) save.currentInventory.items[save.currentInventory.current] = null;
        toEnable.SetActive(true);
        gameObject.SetActive(false);
    }
}
