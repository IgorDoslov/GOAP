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

    public GameObject player;

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

        float dist = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(dist);
        if (dist <= 5f)
        {
            StopAction();
            if (!agentInternalState.HasState("Run"))
                agentInternalState.ModifyInternalState("Run");
        }
        else
        {
            agentInternalState.RemoveState("Run");
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
