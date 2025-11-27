using UnityEngine;

public class A_GetFood : GOAPAction
{
    private bool done = false;

    private void Awake()
    {
        AddEffect("HasFood", true);
        cost = 1f;
    }
    public override bool Perform(WorldState state)
    {
        if (!done)
        {
            Debug.Log("Go get food");

            state["HasFood"] = true;
            done = true;
        }
        return done;


    }

    public override bool IsDone()
    {
        return done;
    }
}
