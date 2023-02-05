using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LaunchGame : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("BUTTON PRESSED");
        SceneManager.LoadScene("Underground_final");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
}
