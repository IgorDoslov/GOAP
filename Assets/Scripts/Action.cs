﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Action : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent navAgent;

    public Dictionary<string, int> preconditionsDic;
    public Dictionary<string, int> effectsDic;

    public WorldStates agentBeliefs;

    public bool running = false;

    public Action()
    {
        preconditionsDic = new Dictionary<string, int>();
        effectsDic = new Dictionary<string, int>();
    }

    public void Awake()
    {
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();

        if (preConditions != null)
            foreach (WorldState w in preConditions)
            {
                preconditionsDic.Add(w.key, w.value);
            }

        if (afterEffects != null)
            foreach (WorldState w in afterEffects)
            {
                effectsDic.Add(w.key, w.value);
            }
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> p in preconditionsDic)
        {
            if (!conditions.ContainsKey(p.Key))
            {
                return false;
            }
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();

    
}