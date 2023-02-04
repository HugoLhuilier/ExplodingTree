using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float shootTime;
    [SerializeField] private Vector2 shootDirection;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float fireForce = 3f;
    [SerializeField] private Transform firePoint;


    void Start()
    {
        StartCoroutine(shoot(shootTime));
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator shoot(float timer)
    {
        float aimAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.Euler(new Vector3(0, 0, aimAngle)));
        bullet.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * fireForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(shootTime);
        StartCoroutine(shoot(shootTime));

    }
}