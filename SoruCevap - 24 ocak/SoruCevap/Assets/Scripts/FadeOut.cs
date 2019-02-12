using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    Color i;

    void Start()
    {
        ButtonControl.toFadeOut += RunCoroutine;
    }

 
    public void RunCoroutine()
    {
        StartCoroutine(FadeTextToFullAlpha(1));
    }

    public IEnumerator FadeTextToFullAlpha(float t)
    {
        if (gameObject.GetComponent<Image>()!=null)
        {
            i = gameObject.GetComponent<Image>().color;
            while (i.a > 0f)
            {

                i = new Color(i.r, i.g, i.b, i.a - (Time.deltaTime / t));
                gameObject.GetComponent<Image>().color = i;
                yield return null;
            }
        }
        if (gameObject.GetComponent<Text>()!=null)
        {
            i = gameObject.GetComponent<Text>().color;
            while (i.a > 0f)
            {

                i = new Color(i.r, i.g, i.b, i.a - (Time.deltaTime / t));
                gameObject.GetComponent<Text>().color = i;
                yield return null;
            }
        }
       // i = new Color(i.r, i.g, i.b, 1);


        
    }
}
