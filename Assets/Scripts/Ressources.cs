using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{

    public int[] resources = new int[4];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(resources[1]);
    }

    public int getCoins(int number)
    {
        return resources[number];
    }
    public void addCoins(int type, int number)
    {
        resources[type] += number; 
    }
}
