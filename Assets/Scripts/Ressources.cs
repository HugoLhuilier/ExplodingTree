using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ressources : MonoBehaviour
{

    public event EventHandler OnDamaged;

    public GameObject healthBar;
    public HealthBarManager healthBarManager;


    private Slider slider;


    public int[] resources = new int[4];
    private float healthPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        resources[0] = 10;
        healthPoints = 100;
        slider = healthBar.GetComponent<Slider>();
        slider.enabled = true;
        slider.value = 100f;
    }


    private void Update()
    {
        slider.value = healthPoints;
    }



    public void GetHit(float damage)
    {
        healthPoints -= damage;

        StartCoroutine(healthBar.GetComponent<HealthBarManager>().ShakeHealthBar(.7f, 2f*damage));

        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);

        healthBarManager.ResetTime();

        if (healthPoints <= 0)
        {
            // Load Gameover screen
        }
    }

    public void GetReward(int reward)
    {
        resources[0] += reward;
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
