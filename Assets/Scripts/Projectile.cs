using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Monster>(out Monster enemyComponent))
        {
            //enemyComponent.GetDamage(damage);
            Impact();
        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            Impact();
        }
    }

    public void Impact()
    {
        //GameObject particules = Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //Destroy(particules, 1);

    }
}
