using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

public class Enemy : Agent
{
    public float hungerTime;
    [HideInInspector]
    public float hungerTimer;

    public float thirstTime;
    [HideInInspector]
    public float thirstTimer;

    new void Start()
    {
        base.Start();

    }

    private void Update()
    {

        hungerTimer += Time.deltaTime;
        thirstTimer += Time.deltaTime;

        if (hungerTimer >= hungerTime && !agentInternalState.HasState("Hungry"))
        {
            GetHungry();
        }

        if (thirstTimer >= thirstTime && !agentInternalState.HasState("Hungry"))
        {
            GetThirsty();
        }
    }

    void GetHungry()
    {
        agentInternalState.ModifyInternalState("Hungry");
        agentInternalState.RemoveState("SatisfyHunger");
    }

    void GetThirsty()
    {
        agentInternalState.ModifyInternalState("Thirsty");
        agentInternalState.RemoveState("SatisfyThirst");

    }
}
