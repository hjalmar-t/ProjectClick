﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMenu : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("TestScene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
