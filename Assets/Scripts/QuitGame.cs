using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class QuitGame : MonoBehaviour
{
  
    void OnMouseDown()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}
