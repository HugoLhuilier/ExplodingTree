using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopClose : MonoBehaviour
{
    public GameObject motherShop;
    [SerializeField] private GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (Vector2.Distance(worldPosition, motherShop.transform.position) > 2)
            {
                Destroy(mainUI);
            }
        }
    }
}
