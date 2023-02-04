using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSpot : MonoBehaviour
{
    private int cost;
    GameObject machine;
    Dialogs diagBox;

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
        if (player.getCoins(1) >= cost)
        {
            player.addCoins(-cost);
            Instantiate(machine);
            Destroy(this.gameObject);
        }
        else
        {
            diagBox.sendMessage("Vous devez posséder " + cost + " pièces pour construire un extracteur ici.");
        }
    }
}
