using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToCredits : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("BUTTON PRESSED");
        SceneManager.LoadScene("Credits");
    }

}


