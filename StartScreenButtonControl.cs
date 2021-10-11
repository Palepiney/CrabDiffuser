using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButtonControl : MonoBehaviour
{
    // When start button is pressed, loads demo scene
    public void selectScene()
    {
        SceneManager.LoadScene("Demo Scene");
    }
}
