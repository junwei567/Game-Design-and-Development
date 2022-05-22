using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Awake() 
    {
        Time.timeScale = 0.0f;
    }

    public void StartButtonClicked() 
    {
        foreach (Transform eachChild in transform) {
            if (eachChild.GetChild(0).name != "Score") {
                Debug.Log("Child found. Name: " + eachChild.GetChild(0).name);
                // disable them
                eachChild.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void RestartButtonClicked() 
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
        Debug.Log("Restart!");
    }

}

