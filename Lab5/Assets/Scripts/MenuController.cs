using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Awake() 
    {
        // Time.timeScale = 0.0f;
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

    // public void AppearRestartButton() {
    //     foreach (Transform eachChild in transform) {
    //         if (eachChild.GetChild(0).name == "Restart") {
    //             Debug.Log("Child found. Name: " + eachChild.GetChild(0).name);
    //             eachChild.gameObject.SetActive(true);
    //         }
    //     }    
    // }

    public void RestartButtonClicked() 
    {
        // foreach (Transform eachChild in transform) {
        //     if (eachChild.GetChild(0).name == "Restart") {
        //         Debug.Log("Child found. Name: " + eachChild.GetChild(0).name);
        //         Time.timeScale = 1.0f;
        //         eachChild.gameObject.SetActive(false);
        //         SceneManager.LoadScene("SampleScene");
        //     }
        // }
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
        Debug.Log("Restart!");
    }

}

