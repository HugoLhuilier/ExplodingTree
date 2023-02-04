using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] private float fadingTime;
    private bool isFading = false;
    private float timeBeforeFade = 0;
    private CanvasGroup group;
    private DialogTextManager text;
    private bool textDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        Transform texttr = transform.Find("Text");
        text = texttr.GetComponent<DialogTextManager>();
        group.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeFade -= Time.deltaTime;
        if (timeBeforeFade < 0 && !isFading && textDisplayed)
        {
            print("Coroutine starts");

            StartCoroutine(Fade());
        }
    }

    public void sendMessage(string msg, float time)
    {
        isFading = false;
        text.setMessage(msg);
        group.alpha = 1;
        timeBeforeFade = time;
        textDisplayed = true;
    }

    IEnumerator Fade()
    {
        isFading = true;
        textDisplayed = false;
        float tfade = 0;
        while (tfade < fadingTime && isFading)
        {
            print(tfade);
            group.alpha = 1 - tfade/fadingTime;
            tfade += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        isFading=false;
        yield return null;
    }
}
