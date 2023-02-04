using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGun : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject wheel;
    [SerializeField] private GameObject yellow;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject orange;
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
        GameObject Yellow = Instantiate(yellow, weapon.transform.position + new Vector3(0, 2), Quaternion.identity);
        GameObject Blue = Instantiate(blue, weapon.transform.position + new Vector3(2, 0), Quaternion.identity);
        GameObject Red = Instantiate(red, weapon.transform.position + new Vector3(-2, 0), Quaternion.identity);
        GameObject Orange = Instantiate(orange, weapon.transform.position + new Vector3(0, -2), Quaternion.identity);
        GameObject Radius = Instantiate(radius, weapon.transform.position, Quaternion.identity);


        Wheel.GetComponent<UIClose>().motherWeapon = weapon;
        Yellow.GetComponent<UIClose>().motherWeapon = weapon;
        Blue.GetComponent<UIClose>().motherWeapon = weapon;
        Red.GetComponent<UIClose>().motherWeapon = weapon;
        Orange.GetComponent<UIClose>().motherWeapon = weapon;
        Radius.GetComponent<UIClose>().motherWeapon = weapon;

        Radius.GetComponent<Radius>().motherWeapon = weapon;
        Yellow.GetComponent<UpgradeGun>().motherWeapon = weapon;
        Red.GetComponent<SellGun>().motherWeapon = weapon;
        Blue.GetComponent<RepairGun>().motherWeapon = weapon;

    }
}

    