using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] int compteur;
    [SerializeField] int generation;
    [SerializeField] int profondeur;
    Boolean touch;
    [SerializeField] GameObject player;
    [SerializeField] int type;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= generation)
        {
            time = 0;
            compteur += profondeur;
        }
        if (touch && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Ressources>().resources[type] = player.GetComponent<Ressources>().resources[type] + compteur;
            print(player.GetComponent<Ressources>().resources[type]);
            compteur = 0;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("player"))
        {
            print("entree");
            touch = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("player"))
        {
            print("sortie");
            touch = false;
          
        }
    }
    
    
}
