﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Agent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        Invoke("GetTired", Random.Range(10, 20));
        Invoke("NeedRelief", Random.Range(10, 20));

    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void NeedRelief()
    {
        beliefs.ModifyState("busting", 0);
        Invoke("NeedRelief", Random.Range(2, 5));
    }

}