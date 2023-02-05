using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{

    [SerializeField] private float maxTimeBeforeShrink = 0.7f;
    [SerializeField] private float quickness = 0.008f;

    public float timer;

    public Image damagedBar;
    private Slider healthBar;

    private Vector3 originalPosition;


    private void Start()
    {
        originalPosition = transform.localPosition;
        timer = maxTimeBeforeShrink;
        healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;


        if(timer <= 0)
        {
            //Debug.Log(healthBar.value + " contre " + damagedBar.fillAmount);
            if (healthBar.value <= damagedBar.fillAmount*100f)  // 
            {
                damagedBar.fillAmount -= (damagedBar.fillAmount - healthBar.value/100f)*quickness;
            }
        }
    }

    /*
    private void HealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(healthSystem.GetHealthNormalized());
    }
    */


    private void Ressources_OnDamaged(object sender, System.EventArgs e)
    {
        timer = maxTimeBeforeShrink;    
    }

    public void ResetTime()
    {
        timer = maxTimeBeforeShrink;
    }

    public IEnumerator ShakeHealthBar(float duration, float magnitude)      // Shaking effect
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float xOff = Random.Range(-1f, 1f);
            float yOff = Random.Range(-1f, 1f);

            transform.localPosition = originalPosition + new Vector3(0, yOff, 0)*magnitude;

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
