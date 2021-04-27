using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class World
{
    private static readonly World instance = new World();
    private static WorldStates worldSt;
    private static Queue<GameObject> patients;

    static World()
    {
        worldSt = new WorldStates();
        patients = new Queue<GameObject>();
    }

    private World()
    { }

    public void AddPatient(GameObject patient)
    {
        patients.Enqueue(patient);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0)
            return null;
        return patients.Dequeue();
    }

    public static World Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return worldSt;
    }

}
