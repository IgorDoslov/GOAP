using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOAP;

[ExecuteInEditMode]
public class GAgentVisual : MonoBehaviour
{
    public Agent thisAgent;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = this.GetComponent<Agent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
