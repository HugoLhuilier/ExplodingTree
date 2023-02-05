using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopGun : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject wheel;
    [SerializeField] private GameObject UIMushroom;
    [SerializeField] private GameObject UICatapult;
    [SerializeField] private GameObject UIFlower;
    [SerializeField] private GameObject UINutLauncher;
    [SerializeField] private GameObject UIRafflesia;

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
        GameObject Wheel = Instantiate(wheel, shop.transform.position, Quaternion.identity);
        GameObject Mushroom = Instantiate(UIMushroom, shop.transform.position + new Vector3(0, 2), Quaternion.identity);
        GameObject Catapult = Instantiate(UICatapult, shop.transform.position + new Vector3(2, 0), Quaternion.identity);
        GameObject Flower = Instantiate(UIFlower, shop.transform.position + new Vector3(-2, 0), Quaternion.identity);
        GameObject NutLauncher = Instantiate(UINutLauncher, shop.transform.position + new Vector3(0, -2), Quaternion.identity);
        GameObject Rafflesia = Instantiate(UIRafflesia, shop.transform.position, Quaternion.identity);


        Wheel.GetComponent<UIShopClose>().motherShop = shop;
        Mushroom.GetComponent<UIShopClose>().motherShop = shop;
        Catapult.GetComponent<UIShopClose>().motherShop = shop;
        Flower.GetComponent<UIShopClose>().motherShop = shop;
        NutLauncher.GetComponent<UIShopClose>().motherShop = shop;
        Rafflesia.GetComponent<UIShopClose>().motherShop = shop;

        Mushroom.GetComponent<BuyGun>().motherShop = shop;
        Catapult.GetComponent<BuyGun>().motherShop = shop;
        Flower.GetComponent<BuyGun>().motherShop = shop;
        NutLauncher.GetComponent<BuyGun>().motherShop = shop;
        Rafflesia.GetComponent<BuyGun>().motherShop = shop;


    }
}
