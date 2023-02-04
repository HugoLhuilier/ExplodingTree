using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{

    public int[] resources = new int[4];
    
    // Start is called before the first frame update
    void Start()
    {
        resources[0] = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCoins()
    {
        return resources[0];
    }
    public void addCoins(int value)
    {
        resources[0] += value; 
    }
}
