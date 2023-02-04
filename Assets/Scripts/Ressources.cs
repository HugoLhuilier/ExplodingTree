using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ressources : MonoBehaviour
{
    
   

    [SerializeField] private GameObject healthBar;

    private Slider slider;


    public int[] resources = new int[4];
    private float healthPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
        resources[0] = 10;
<<<<<<< HEAD
        healthPoints = 100;
        slider = healthBar.GetComponent<Slider>();
        slider.enabled = true;
=======
        healthPoints = 100f;
>>>>>>> main
    }


    private void Update()
    {
<<<<<<< HEAD
        slider.value = healthPoints;
=======
        
>>>>>>> main
    }



    public void GetHit(float damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            // Load Gameover screen
        }
    }

<<<<<<< HEAD
    public void GetReward(int reward)
    {
        resources[0] += reward;
    }
=======
>>>>>>> main

    public int getCoins()
    {
        return resources[0];
    }
    public void addCoins(int value)
    {
        resources[0] += value; 
    }

}
