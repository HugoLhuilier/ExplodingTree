using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{
    float compteur = 0;
    [SerializeField] int profondeur;
    [SerializeField] int generate;
    [SerializeField] int resources;
    [SerializeField] GameObject player;
    [SerializeField] int type;
    Boolean collide;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
