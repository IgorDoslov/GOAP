using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class WorldInterface : MonoBehaviour
{
    GameObject focusObject;
    ResourceData focusObjectData;
    GameObject newResourcePrefab;
    public GameObject[] allResources;
    public GameObject hospital;
    Vector3 goalPos;
    public NavMeshSurface surface;
    Vector3 clickOffset = Vector3.zero;
    bool offsetCalc = false;
    bool deleteResource = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MouseOnHoverTrash()
    {
        deleteResource = true;
    }

    public void MouseOutHoverTrash()
    {
        deleteResource = false;
    }

    public void ActivateToilet()
    {
        newResourcePrefab = allResources[0];
    }

    public void ActivateCubicle()
    {
        newResourcePrefab = allResources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit))
                return;

            offsetCalc = false;
            clickOffset = Vector3.zero;

            Resource r = hit.transform.gameObject.GetComponent<Resource>();


            if (r != null)
            {
                focusObject = hit.transform.gameObject;
                focusObjectData = r.info;
            }
            else if (newResourcePrefab != null)
            {
                goalPos = hit.point;
                focusObject = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
                focusObjectData = focusObject.GetComponent<Resource>().info;
            }

            if (focusObject)
            {
                focusObject.GetComponent<Collider>().enabled = false;

            }

        }
        else if (focusObject && Input.GetMouseButtonUp(0))
        {
            if (deleteResource)
            {
                World.Instance.GetQueue(focusObjectData.resourceQueue).RemoveResource(focusObject);
                World.Instance.GetWorld().ModifyState(focusObjectData.resourceState, -1);
                Destroy(focusObject);
            }
            else
            {
                focusObject.transform.parent = hospital.transform;
                World.Instance.GetQueue(focusObjectData.resourceQueue).AddResource(focusObject);
                World.Instance.GetWorld().ModifyState(focusObjectData.resourceState, 1);
                focusObject.GetComponent<Collider>().enabled = true;

            }

            surface.BuildNavMesh();

            focusObject = null;

        }
        else if (focusObject && Input.GetMouseButton(0))
        {
            int layerMask = 1 << 8;
            RaycastHit hitMove;
            Ray rayMove = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(rayMove, out hitMove, Mathf.Infinity, layerMask))
                return;

            if (!offsetCalc)
            {
                clickOffset = hitMove.point - focusObject.transform.position;
                offsetCalc = true;
            }

            goalPos = hitMove.point;
            focusObject.transform.position = goalPos;
        }

        if (focusObject && (Input.GetKeyDown(KeyCode.Less) || Input.GetKeyDown(KeyCode.Comma)))
        {
            focusObject.transform.Rotate(0, 90, 0);
        }
        else if (focusObject && (Input.GetKeyDown(KeyCode.Greater) || Input.GetKeyDown(KeyCode.Period)))
        {
            focusObject.transform.Rotate(0, -90, 0);
        }
    }
}
