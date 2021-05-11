using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using GOAP;

namespace GOAP
{

    public sealed class World : MonoBehaviour
    {
        [System.Serializable]
        public class InspectorResource
        {
            [TagSelector]
            public string tag;
            public string modifier;
        }

       // private static readonly World instance = new World();
        private static WorldStates worldSt;
        //private static ResourceQueue patients;
        //private static ResourceQueue cubicles;
        //private static ResourceQueue offices;
        //private static ResourceQueue toilets;
        //private static ResourceQueue wees;
        private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

        public List<InspectorResource> resourceConfig = new List<InspectorResource>();

        public void Start()
        {
            worldSt = new WorldStates();

            foreach (var r in resourceConfig)
            {
                var res = new ResourceQueue(r.tag,r.modifier,worldSt);
                resources.Add(r.tag, res);
            }

            //var patients = new ResourceQueue("", "", worldSt);
            //resources.Add("patients", patients);

            //var cubicles = new ResourceQueue("Cubicle", "FreeCubicle", worldSt);
            //resources.Add("cubicles", cubicles);

            //var offices = new ResourceQueue("Office", "FreeOffice", worldSt);
            //resources.Add("offices", offices);

            //var toilets = new ResourceQueue("Toilet", "FreeToilet", worldSt);
            //resources.Add("toilets", toilets);

            //var wees = new ResourceQueue("Wee", "FreeWee", worldSt);
            //resources.Add("wees", wees);

            Time.timeScale = 5;
        }

        private static World instance;

        void Awake()
        {

            if (instance == null)
            {

                instance = this;
                DontDestroyOnLoad(this.gameObject);

                //Rest of your Awake code

            }
            else
            {
                Destroy(this);
            }
        }

        public ResourceQueue GetQueue(string type)
        {
            return resources[type];
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
}