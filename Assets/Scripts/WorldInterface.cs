using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInterface : MonoBehaviour
{
    GameObject focusObject;
    public GameObject newResourcePrefab;
    public GameObject hospital;
    Vector3 goalPos;
    public NavMeshSurface surface;
    Vector3 clickOffset = Vector3.zero;
    bool offsetCalc = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit))
                return;

            if (hit.transform.gameObject.tag == "Toilet")
            {
                focusObject = hit.transform.gameObject;
            }
            else
            {
                goalPos = hit.point;
                focusObject = Instantiate(newResourcePrefab, goalPos, newResourcePrefab.transform.rotation);
            }

            focusObject.GetComponent<Collider>().enabled = false;

        }
        else if (focusObject && Input.GetMouseButtonUp(0))
        {
            focusObject.transform.parent = hospital.transform;
            surface.BuildNavMesh();
            World.Instance.GetQueue("toilets").AddResource(focusObject);
            World.Instance.GetWorld().ModifyState("FreeToilet", 1);
            focusObject.GetComponent<Collider>().enabled = true;

            focusObject = null;

        }
        else if (focusObject && Input.GetMouseButton(0))
        {
            RaycastHit hitMove;
            Ray rayMove = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(rayMove, out hitMove))
                return;

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
