using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Entity
{
    public string sceneName;

    public override void Interract() {
        SceneManager.LoadScene(sceneName);
    }
}
