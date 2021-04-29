using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class World
{
    private static readonly World instance = new World();
    private static WorldStates worldSt;
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;
    private static Queue<GameObject> offices;
    private static Queue<GameObject> toilets;

    static World()
    {
        worldSt = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        offices = new Queue<GameObject>();
        toilets = new Queue<GameObject>();

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubes)
        {
            cubicles.Enqueue(c);
        }
        if (cubes.Length > 0)
            worldSt.ModifyState("FreeCubicle", cubes.Length);

        GameObject[] offcs = GameObject.FindGameObjectsWithTag("Office");
        foreach (GameObject o in offcs)
        {
            offices.Enqueue(o);
        }
        if (offcs.Length > 0)
            worldSt.ModifyState("FreeOffice", offcs.Length);

        GameObject[] tois = GameObject.FindGameObjectsWithTag("Toilet");
        foreach (GameObject t in tois)
        {
            toilets.Enqueue(t);
        }
        if (tois.Length > 0)
            worldSt.ModifyState("FreeToilet", tois.Length);

        Time.timeScale = 5;
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
    public void AddOffice(GameObject office)
    {
        offices.Enqueue(office);
    }

    public GameObject RemoveOffice()
    {
        if (offices.Count == 0)
            return null;
        return offices.Dequeue();
    }

    public void AddToilet(GameObject toilet)
    {
        toilets.Enqueue(toilet);
    }

    public GameObject RemoveToilet()
    {
        if (toilets.Count == 0)
            return null;
        return toilets.Dequeue();
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
