using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubGoal
{
    public Dictionary<string, int> subGoals;
    public bool remove;

    public SubGoal(string s, int i, bool r)
    {
        subGoals = new Dictionary<string, int>();
        subGoals.Add(s, i);
        remove = r;
    }
}

public class Agent : MonoBehaviour
{
    public List<Action> actions = new List<Action>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();

    Planner planner;
    Queue<Action> actionQueue;
    public Action currentAction;
    SubGoal currentGoal;

    // Start is called before the first frame update
    public void Start()
    {
        Action[] acts = this.GetComponents<Action>();
        foreach (Action a in acts)
            actions.Add(a);
    }

    bool invoked = false;
    void CompleteAction()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(currentAction != null && currentAction.running)
        {
            if(currentAction.navAgent.hasPath && currentAction.navAgent.remainingDistance < 1f)
            {
                if(!invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            return;
        }

        if(planner == null || actionQueue == null)
        {
            planner = new Planner();

            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            foreach(KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.Plan(actions, sg.Key.subGoals, null); // trying to create a plan for the most important goal
                if(actionQueue != null)
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }
        if(actionQueue != null && actionQueue.Count == 0)
        {
            if(currentGoal.remove)
            {
                goals.Remove(currentGoal);
            }
            planner = null;
        }

        if(actionQueue != null && actionQueue.Count > 0)
        {
            currentAction = actionQueue.Dequeue();
            if(currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);

                if(currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.navAgent.SetDestination(currentAction.target.transform.position);
                }
            }
            else
            {
                actionQueue = null; // go get a new plan
            }
        }

    }
}
