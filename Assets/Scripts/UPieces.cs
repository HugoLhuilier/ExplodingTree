using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upieces : MonoBehaviour
{
    [SerializeField] Text red;
    [SerializeField] Text blue;
    [SerializeField] Text orange;
    [SerializeField] Text pieces;
    [SerializeField] GameObject perso;
    int[] resources;
    

    // Start is called before the first frame update
    void Start()
    {
        red = GameObject.Find("Orange").GetComponent<Text>();
        pieces = GameObject.Find("Pieces").GetComponent<Text>();
        blue = GameObject.Find("Bleu").GetComponent<Text>();
        orange = GameObject.Find("Orange").GetComponent<Text>();
        resources = perso.GetComponent<Ressources>().resources;
        print(resources[0]);


    }

    // Update is called once per frame
    void Update()
    {
        pieces.text = resources[0].ToString();
        red.text = resources[1].ToString();
        blue.text = resources[2].ToString();
        orange.text = resources[3].ToString();
        print(resources);

    }
}
