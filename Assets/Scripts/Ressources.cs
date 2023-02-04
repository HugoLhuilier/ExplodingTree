using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{

    private int coins;
    public int greenMat;
    public int blueMat;
    public int redMat;
    public int brownMat;




    public int[] resources = new int[4];
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public int getCoins()
    {
        return coins;
    }

    public void addCoins(int qtt)
    {
        coins += qtt;

        print(resources[1]);

    }
}
