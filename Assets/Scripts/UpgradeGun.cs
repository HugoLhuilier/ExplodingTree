using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeGun : MonoBehaviour
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
        motherWeapon.GetComponent<GunShooter>().damage *= 2;
        GameObject[] UIObject = GameObject.FindGameObjectsWithTag("UIObject");
        foreach(GameObject obj in UIObject)
        {
            Destroy(obj);
        }

    }
}
