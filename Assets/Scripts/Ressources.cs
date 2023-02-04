using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    
   

    public int[] resources = new int[4];
    private float healthPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
        resources[0] = 10;
        healthPoints = 100f;
    }


    public void GetHit(float damage)
    {
<<<<<<< HEAD

        
        

=======
>>>>>>> e4d0918f1cfbc86577ad6b76664c2f6593874531
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            // Load Gameover screen
        }
<<<<<<< HEAD

=======
>>>>>>> e4d0918f1cfbc86577ad6b76664c2f6593874531
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
