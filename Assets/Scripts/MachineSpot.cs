using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpot : MonoBehaviour
{
    public int cost;
    public GameObject machine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void wantBuy(Ressources player)
    {
        if (player.getCoins() >= cost)
        {
            player.addCoins(-cost);
            Instantiate(machine);
        }
        else
        {

        }
    }
}
