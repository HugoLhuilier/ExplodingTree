using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Dialogs dialogBox;

    private void Start()
    {
    }
    public void displayTest()
    {
        dialogBox.sendMessage("Ceci est un nombre aléatoire : " + Random.Range(0, 1000), 5);
    }
}
