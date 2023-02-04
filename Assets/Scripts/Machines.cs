using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] float time;
    [SerializeField] int compteur;
    [SerializeField] int generation;
    [SerializeField] int profondeur;
    Boolean touch;
    [SerializeField] GameObject player;
    [SerializeField] int type;
=======
=======
>>>>>>> origin/UndergroundTom
    float compteur = 0;
    [SerializeField] int profondeur;
    [SerializeField] int generate;
    [SerializeField] int resources;
    [SerializeField] GameObject player;
    [SerializeField] int type;
    Boolean collide;

<<<<<<< HEAD
>>>>>>> origin/UndergroundTom
=======
>>>>>>> origin/UndergroundTom
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        time += Time.deltaTime;
        if (time >= generation)
        {
            time = 0;
            compteur += profondeur;
        }
        if (touch && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<Ressources>().resources[type] = player.GetComponent<Ressources>().resources[type] + compteur;
            compteur = 0;
        }
        
=======
=======
>>>>>>> origin/UndergroundTom
        compteur += Time.deltaTime;
        if (compteur >= generate)
        {
            compteur -= generate;
            resources += profondeur;
        }
        if (Input.GetKeyDown(KeyCode.E) && collide)
        {
            player.GetComponent<PLayerMovement>().resources[type] += resources;
            resources = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            collide = true;
        }
<<<<<<< HEAD
>>>>>>> origin/UndergroundTom
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("player"))
        {
            touch = true;
           
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("player"))
        {

            touch = false;
          
        }
=======
>>>>>>> origin/UndergroundTom
    }
}
