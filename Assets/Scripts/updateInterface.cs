using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateInterface : MonoBehaviour
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
        red = GameObject.Find("Vert").GetComponent<Text>();
        pieces = GameObject.Find("Pièces").GetComponent<Text>();
        blue = GameObject.Find("Bleu").GetComponent<Text>();
        orange = GameObject.Find("Orange").GetComponent<Text>();
        resources = perso.GetComponent<Ressources>().resources;
       


    }

    // Update is called once per frame
    void Update()
    {
        
        pieces.text = perso.GetComponent<Ressources>().resources[0].ToString();
        red.text = perso.GetComponent<Ressources>().resources[1].ToString();
        blue.text =  perso.GetComponent<Ressources>().resources[2].ToString();
        orange.text = perso.GetComponent<Ressources>().resources[3].ToString();



    }
}
