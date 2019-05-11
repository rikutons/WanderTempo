using UnityEngine;
using System.Collections;
using UniRx;
using UniRx.Triggers;
using System;


public class IntervalSample : Base
{

    // Use this for initialization
    void Start()
    {

        //50msñàÇ…çwì«Ç∑ÇÈ
        Observable.Interval(TimeSpan.FromMilliseconds(50)).Subscribe(a =>
        {
            //óŒêFÇ…ãﬂÇ√ÇØÇÈ
            GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, a / 200.0f);
        }).AddTo(this);
    }

}