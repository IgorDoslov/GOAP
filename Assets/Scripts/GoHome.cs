using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        Destroy(this.gameObject);
        return true;
    }
}
