using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMainTitle : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("BUTTON PRESSED");
        SceneManager.LoadScene("TitleScreen");
    }

}
