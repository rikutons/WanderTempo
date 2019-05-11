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

        //50ms���ɍw�ǂ���
        Observable.Interval(TimeSpan.FromMilliseconds(50)).Subscribe(a =>
        {
            //�ΐF�ɋ߂Â���
            GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, a / 200.0f);
        }).AddTo(this);
    }

}