using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGun : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject wheel;
    [SerializeField] private GameObject UIUpgrade;
    [SerializeField] private GameObject UIRepair;
    [SerializeField] private GameObject UIOvercharge;
    [SerializeField] private GameObject UISell;
    [SerializeField] private GameObject radius;
    public float range;

    

    // Start is called before the first frame update
    void Start()
    {
        range = weapon.GetComponent<GunShooter>().range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
        {
        GameObject Wheel = Instantiate(wheel, weapon.transform.position, Quaternion.identity);
        GameObject Upgrade = Instantiate(UIUpgrade, weapon.transform.position + new Vector3(0, 2), Quaternion.identity);
        GameObject Repair = Instantiate(UIRepair, weapon.transform.position + new Vector3(2, 0), Quaternion.identity);
        GameObject Overcharge = Instantiate(UIOvercharge, weapon.transform.position + new Vector3(-2, 0), Quaternion.identity);
        GameObject Sell = Instantiate(UISell, weapon.transform.position + new Vector3(0, -2), Quaternion.identity);
        GameObject Radius = Instantiate(radius, weapon.transform.position, Quaternion.identity);


        Wheel.GetComponent<UIClose>().motherWeapon = weapon;
        Upgrade.GetComponent<UIClose>().motherWeapon = weapon;
        Repair.GetComponent<UIClose>().motherWeapon = weapon;
        Overcharge.GetComponent<UIClose>().motherWeapon = weapon;
        Sell.GetComponent<UIClose>().motherWeapon = weapon;
        Radius.GetComponent<UIClose>().motherWeapon = weapon;

        Radius.GetComponent<Radius>().motherWeapon = weapon;
        Upgrade.GetComponent<UpgradeGun>().motherWeapon = weapon;
        Sell.GetComponent<SellGun>().motherWeapon = weapon;
        Repair.GetComponent<RepairGun>().motherWeapon = weapon;
        Overcharge.GetComponent<OverchargeGun>().motherWeapon = weapon;

    }
}

    
