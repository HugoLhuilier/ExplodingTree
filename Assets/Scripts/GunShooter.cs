using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    //Tir de projectile
    [SerializeField] private GameObject gun;
    [SerializeField] private float shootTime;
    [SerializeField] private GameObject projectile;
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
        StartCoroutine(Shoot(shootTime));

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
            print(probability);
            TargetClosest();
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
                print(distance);

            }
        }
    }
    IEnumerator Shoot(float shootTime)
    {
        while (!inRange || broken)
        {
            yield return new WaitForFixedUpdate();
        }
        float aimAngle = Mathf.Atan2(closestMonster.transform.position.y - transform.position.y, closestMonster.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        print(aimAngle);
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.Euler(new Vector3(0, 0, aimAngle)));
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(closestMonster.transform.position.x - transform.position.x, closestMonster.transform.position.y - transform.position.y).normalized * fireForce, ForceMode2D.Impulse);
        Destroy(bullet, 7);
        yield return new WaitForSeconds(shootTime);
        StartCoroutine(Shoot(shootTime));

    }
}