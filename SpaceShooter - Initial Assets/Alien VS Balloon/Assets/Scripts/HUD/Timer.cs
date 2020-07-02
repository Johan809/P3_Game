using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text counter;
    private static float startTime = 0;
    private float min, sec;

    void Start()
    {
        startTime = Time.time;
        counter = GetComponent<Text>();
    }

    void Update()
    {
        float time = Time.time - startTime;
        min = (int)(time / 60f);
        sec = (int)(time % 60f);
        if (min > 9)
        {
            counter.rectTransform.localPosition = new Vector3(161.71f, counter.rectTransform.localPosition.y, counter.rectTransform.localPosition.z);
            counter.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 102.4f);
        }
        counter.text = $"{min:0}:{sec:00}";
    }

    public void ResetTimer() => startTime = 0;

}