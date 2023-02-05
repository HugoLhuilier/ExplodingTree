using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [SerializeField] private bool doRotation;
    [SerializeField] private bool triple;

    //Tir de projectile
    [SerializeField] private GameObject gun;
    public float shootSpeed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectile2;
    [SerializeField] private float fireForce;
    public float damage;
    [SerializeField] private Transform firePoint;
    public float range;

    //targetEntity
    private float closestDistance;
    private GameObject closestMonster;
    private GameObject[] monsterArray;
    private bool inRange;
    private bool side;

    //réparation
    private float probability = 0f;
    private bool broken = false;
    [SerializeField] private GameObject brokenIcon;

    //Overcharge
    public float overchargeTime = 0f;
    public bool overcharge = false;

    //Animation
    //private Animator myAnimator;
    //private SpriteRenderer mySpriteRenderer;

    //private void Awake()
    //{
    //    myAnimator = transform.GetComponent<Animator>();
    //    mySpriteRenderer = GetComponent<SpriteRenderer>();

    //}

    void Start()
    {
        brokenIcon.SetActive(false);

        
        monsterArray = GameObject.FindGameObjectsWithTag("Monster");
        closestDistance = range;
        inRange = false;
        foreach (GameObject obj in monsterArray)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = obj;
                inRange = true;
                
            }
        }
        StartCoroutine(Shoot(shootSpeed));

    }

    // Update is called once per frame
    void Update()
    {
        if(broken)
        {
            return;
        }
        else if(Random.Range(0f, 100f) < probability)
        {
            broken = true;
            brokenIcon.SetActive(true);
        }
        
        else
        {
            probability += 0.00005f * Time.deltaTime;
            TargetClosest();
        }
        if(overchargeTime > 0f)
        {
            overchargeTime -= Time.deltaTime;
            if (overchargeTime < 0f)
            {
                shootSpeed *= 4f;
                overcharge = false;

            }
        }

    }

    public void repairGun()
    {
        broken = false;
        brokenIcon.SetActive(false);
        probability = 0f;
    }

    
    void TargetClosest()
    {
        monsterArray = GameObject.FindGameObjectsWithTag("Monster");
        closestDistance = range / 2f;
        inRange = false;

        foreach (GameObject obj in monsterArray)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestMonster = obj;
                inRange = true;

            }
        }
    }
    IEnumerator Shoot(float time)
    {
        while (!inRange || broken)
        {
            yield return new WaitForFixedUpdate();
        }
        float aimAngle = Mathf.Atan2(closestMonster.transform.position.y - transform.position.y, closestMonster.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.Euler(new Vector3(0, 0, aimAngle)));
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(closestMonster.transform.position.x - transform.position.x, closestMonster.transform.position.y - transform.position.y).normalized * fireForce, ForceMode2D.Impulse);
        bullet.GetComponent<Projectile>().damage = damage;
        //myAnimator.SetTrigger("Fire");
        Destroy(bullet, 7);
        //rotation
        if(triple)
        {
            GameObject bullet2 = Instantiate(projectile2, firePoint.position, Quaternion.Euler(new Vector3(0, 0, aimAngle + 10)));
            GameObject bullet3 = Instantiate(projectile2, firePoint.position, Quaternion.Euler(new Vector3(0, 0, aimAngle + 10)));
            bullet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(closestMonster.transform.position.x - transform.position.x, closestMonster.transform.position.y - transform.position.y + 1).normalized * fireForce, ForceMode2D.Impulse);
            bullet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(closestMonster.transform.position.x - transform.position.x, closestMonster.transform.position.y - transform.position.y + 1).normalized * fireForce, ForceMode2D.Impulse);
            bullet2.GetComponent<Projectile>().damage = damage;
            bullet3.GetComponent<Projectile>().damage = damage;
            Destroy(bullet2, 7);
            Destroy(bullet3, 7);
            gun.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if (doRotation)
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));

        }
        

        yield return new WaitForSeconds(time);
        StartCoroutine(Shoot(shootSpeed));

    }
}