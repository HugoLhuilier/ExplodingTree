using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverchargeGun : MonoBehaviour
{
    public GameObject motherWeapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (!motherWeapon.GetComponent<GunShooter>().overcharge)
        {
            motherWeapon.GetComponent<GunShooter>().overcharge = true;
            motherWeapon.GetComponent<GunShooter>().overchargeTime = 10f;
            motherWeapon.GetComponent<GunShooter>().shootSpeed /= 4f;
        }
        GameObject[] UIObject = GameObject.FindGameObjectsWithTag("UIObject");
        foreach (GameObject obj in UIObject)
        {
            Destroy(obj);
        }

    }
}
