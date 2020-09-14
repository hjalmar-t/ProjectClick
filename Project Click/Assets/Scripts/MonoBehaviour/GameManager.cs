using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveGame save;
    public GameObject playerPrefab;

    private void Start() {
        if(playerPrefab != null) {
            save.currentInventory.Copy(save.savedInventory);

            GameObject playerObject = Instantiate(playerPrefab, save.playerPosition, Quaternion.identity);
            save.SetPlayer(playerObject);
        }
    }
}
