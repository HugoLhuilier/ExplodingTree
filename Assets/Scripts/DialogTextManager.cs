using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogTextManager : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMessage(string msg)
    {
        print("message : " + msg);
        text.text = msg;
    }
}
