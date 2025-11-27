using UnityEngine;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

public class GOAPPlanner 
{
    public Queue<GOAPAction> Plan(WorldState worldState,List<GOAPAction> availableActions,GOAPGoal goal)
    {
        List<GOAPAction>plan = new List<GOAPAction>();

        WorldState currentState = new WorldState();

        foreach(var keyValue in worldState)
        {
            currentState[keyValue.Key] = keyValue.Value;
        }

        // iteramos hasta cumplir el goal.
        int safeLock = 0;

        while(!GoalSatisfied(currentState, goal.DesiredState) && safeLock < 99)
        {
            safeLock++;

            GOAPAction bestAction = null;

            foreach(var action in availableActions)
            {
                // En el estado actual, se cumplen las precondiciones?
                if (!action.ArePreconditionsMet(currentState))
                {
                    Debug.LogWarning("No preconditions met for " + action.GetType());
                    continue;
                }

                //bool improves = false;
                //foreach(var effect in action.Effects)
                //{
                //    if(goal.DesiredState.ContainsKey(effect.Key)&& 
                //       (currentState.ContainsKey(effect.Key)||
                //       !currentState[effect.Key].Equals(effect.Value)))
                //    {
                //        improves = true;
                //        break;
                //    }
                //}

                //if (!improves) {

                //    continue;

                //}

                if(bestAction == null || action.cost < bestAction.cost) {
                    bestAction = action;
                }
            }

            if(bestAction == null)
            {
                Debug.Log("Planner: No encontré ninguna acción que me acerque al goal");
                return null;
            }

            foreach(var effect in bestAction.Effects) {
                currentState[effect.Key] = effect.Value;
            }




            plan.Add(bestAction);
        }

        if(!GoalSatisfied(currentState, goal.DesiredState))
        {
            Debug.Log("Planner; no se pudo cumplir el goal aunque se intentó");
            return null;

        }
        Debug.Log("Se genero un plan con: "+ plan.Count + " acciones");

        return new Queue<GOAPAction>(plan);


    }

    private bool GoalSatisfied(WorldState state, Dictionary<string, object> goalState)
    {
        foreach(var goal in goalState)
        {
            if(!state.ContainsKey(goal.Key))
                return false;
            if (!state[goal.Key].Equals(goal.Value)) 
                return false;
        }

        return true;
    }
}
