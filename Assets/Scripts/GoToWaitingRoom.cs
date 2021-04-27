using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetWorld().ModifyState("Waiting", 1);
        World.Instance.AddPatient(this.gameObject);
        return true;
    }
}
