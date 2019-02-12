using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntroFadeIn : MonoBehaviour {


    Color defaultColor;

    void Start()
    {
        if (gameObject.GetComponent<Image>()!=null)
        {
            defaultColor = gameObject.GetComponent<Image>().color;
        }
        if (gameObject.GetComponent<Text>()!=null)
        {
            defaultColor = gameObject.GetComponent<Text>().color;
        }
        if (this!=null)
        {
            ButtonControl.toFadeIn += RunCoroutine;
        }
        
        StartCoroutine(FadeTextToFullAlpha(1f));
    }


    void RunCoroutine()
    {
        StartCoroutine(FadeTextToFullAlpha(1));
    }

    public IEnumerator FadeTextToFullAlpha(float t)
    {
        Color i = defaultColor;
        i = new Color(i.r, i.g, i.b, 0);

        if (gameObject.GetComponent<Image>() != null)
        {
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Image>().color = i;
                yield return null;
            }
        }
        if (gameObject.GetComponent<Text>() != null)
        {
            while (i.a < 1.0f)
            {

                i = new Color(i.r, i.g, i.b, i.a + (Time.deltaTime / t));
                gameObject.GetComponent<Text>().color = i;
                yield return null;
            }
        }
       
    }
}
