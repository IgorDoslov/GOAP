﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GoToWaitingRoom : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetWorld().ModifyState("Waiting", 1);
        World.Instance.GetQueue("Patient").AddResource(gameObject);
        beliefs.ModifyState("atHospital", 1);
        return true;
    }
}
