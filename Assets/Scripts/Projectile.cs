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

    /*
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Monster enemyComponent))
        {
            enemyComponent.GetDamage(damage);
            StartCoroutine(enemyComponent.ChangeToRed());
            Destroy(gameObject);


        }

        else if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }
    }

    */
}
