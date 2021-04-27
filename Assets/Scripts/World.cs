using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class World
{
    private static readonly World instance = new World();
    private static WorldStates worldSt;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;
    
    static World()
    {
        worldSt = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
        {
            cubicles.Enqueue(c);
        }
        if (cubes.Length > 0)
            worldSt.ModifyState("FreeCubicle", cubes.Length);
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

    public void AddCubicle(GameObject cubicle)
    {
        cubicles.Enqueue(cubicle);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0)
            return null;
        return cubicles.Dequeue();
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
