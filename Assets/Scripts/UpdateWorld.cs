﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GOAP;

public class UpdateWorld : MonoBehaviour
{
    public Text states;

    // Update is called once per frame
    void LateUpdate()
    {
        Dictionary<string, int> worldstates = World.Instance.GetStateCollection().GetStateDictionary();
        states.text = "";
        foreach(KeyValuePair<string, int> s in worldstates)
        {
            states.text += s.Key + ", " + s.Value + "\n";
        }
    }
}
