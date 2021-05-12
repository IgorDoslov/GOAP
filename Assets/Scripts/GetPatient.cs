using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class GetPatient : Action
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = World.Instance.GetQueue("Patient").RemoveResource();
        if (target == null)
            return false;

        resource = World.Instance.GetQueue("Cubicle").RemoveResource();
        if (resource != null)
        {
            inventory.AddItem(resource);
        }
        else
        {
            World.Instance.GetQueue("Patient").AddResource(target);
            target = null;
            return false;
        }
        World.Instance.GetStateCollection().ModifyState("FreeCubicle", -1);
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetStateCollection().ModifyState("Waiting", -1);
        if(target)
        {
            target.GetComponent<Agent>().inventory.AddItem(resource);
        }
        return true;
    }
}
