using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private float fadingTime;
    [SerializeField] private GameObject fader;
    private Image image;

    private void Start()
    {
        fader.SetActive(false);
        image = fader.GetComponent<Image>();
    }
    public void startClicked()
    {
        StartCoroutine(Fade());
    }

    public void exitClicked()
    {
        Application.Quit();
    }

    IEnumerator Fade()
    {
        float tFade = 0;
        fader.SetActive(true);
        while (tFade < fadingTime)
        {
            image.color = new Color(0,0,0,tFade/fadingTime);
            yield return new WaitForFixedUpdate();
            tFade += Time.fixedDeltaTime;
        }
        SceneManager.LoadScene("MainScene");
    }
}
