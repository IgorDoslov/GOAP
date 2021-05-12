using System.Collections;
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
        World.Instance.GetStateCollection().ModifyState("Waiting", 1);
        World.Instance.GetQueue("Patient").AddResource(gameObject);
        internalState.ModifyState("atHospital", 1);
        return true;
    }
}
