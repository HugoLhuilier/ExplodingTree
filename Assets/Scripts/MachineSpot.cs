using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpot : MonoBehaviour
{
    private int cost;
    GameObject machine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy(Ressources player)
    {
        if (player.getCoins() >= cost)
        {
            //FAIRE BAISSER THUNES DU JOUEUR
            Instantiate(machine);
        }
        else
        {

        }
    }
}
