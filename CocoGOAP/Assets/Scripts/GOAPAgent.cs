using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
/// <summary>
/// Este scriptt va a gestionar:
/// Estado del mundo, objetivos,se conectaa al planner y ejecutaa el plan de acción
/// </summary>
public class GOAPAgent : MonoBehaviour
{
    public List<GOAPAction> actions = new List<GOAPAction>();
    public List<GOAPGoal> goals = new List<GOAPGoal>();


    private GOAPPlanner planner = new GOAPPlanner();
    private Queue<GOAPAction> currentPlan;

    public bool autoReplainIfFinished = false;

    public WorldState worldState = new WorldState();

    private void Start()
    {
        worldState["HasFood"] = false;   
        worldState["IsSatisfied"] = false;

        GOAPAction[] possibleActions = GetComponents<GOAPAction>(); 
        actions.AddRange(possibleActions);

        var eatGoal = new GOAPGoal("Eat", 1f);
        eatGoal.DesiredState["IsSatisfied"] = true;
        goals.Add(eatGoal);

        Plan();
    }
    void Plan()
    {
        if (goals.Count == 0)
        {
            Debug.LogWarning("Agent: No defined goals");
            return;
        }


        GOAPGoal goal = goals[0];
        currentPlan = planner.Plan(worldState, actions ,goal); 

        if(currentPlan == null)
        {
            Debug.LogWarning("Agent: No plan found for" + goal.name);
        }
        else
        {
            Debug.Log("Agent: Plan created with" + actions.Count + "actions.");

        }
    }

    private void Update()
    {
        if(currentPlan == null||currentPlan.Count == 0)
        {
            if (autoReplainIfFinished)
            {
                Plan();
            }
            return;
        }

        var action = currentPlan.Peek();

        bool done = action.Perform(worldState);

        if (done)
        {
            Debug.Log("Agent: Completed action:" + action.GetType().Name);
            currentPlan.Dequeue();
        }
    }
}
