using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGun : MonoBehaviour
{
    public GameObject motherShop;
    [SerializeField] private GameObject tower;

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
        Instantiate(tower, motherShop.transform.position, Quaternion.identity);

        GameObject[] UIObject = GameObject.FindGameObjectsWithTag("UIObject");
        foreach (GameObject obj in UIObject)
        {
            Destroy(obj);
        }
        Destroy(motherShop);

    }
}
