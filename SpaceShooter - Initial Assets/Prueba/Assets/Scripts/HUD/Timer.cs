using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text counter;
    private float min, sec;

    void Start()
    {
        counter = GetComponent<Text>();
    }

    void Update()
    {
        min = (int)(Time.time / 60f);
        sec = (int)(Time.time % 60f);
        if (min > 9)
        {
            counter.rectTransform.localPosition = new Vector3(161.71f, counter.rectTransform.localPosition.y, counter.rectTransform.localPosition.z);
            counter.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 102.4f);
        }
        counter.text = $"{min:0}:{sec:00}";
    }
}