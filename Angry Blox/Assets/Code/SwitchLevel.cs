using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    public void changeScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
