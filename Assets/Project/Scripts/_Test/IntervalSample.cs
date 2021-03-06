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

        //50ms毎に購読する
        Observable.Interval(TimeSpan.FromMilliseconds(50)).Subscribe(a =>
        {
            //緑色に近づける
            GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, a / 200.0f);
        }).AddTo(this);
    }

}