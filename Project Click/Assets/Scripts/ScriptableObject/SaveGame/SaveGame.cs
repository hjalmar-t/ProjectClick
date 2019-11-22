using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SaveGame : ScriptableObject
{
    public Inventory currentInventory;
    public Inventory savedInventory;
    public string levelName;
    public Vector3 playerPosition;
}
