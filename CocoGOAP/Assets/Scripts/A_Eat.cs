using UnityEngine;

public class A_Eat : GOAPAction
{
    private bool done = false;

    private void Awake()
    {
        AddPrecondition("HasFood", true);

        AddEffect("IsSatisfied", true);

        AddEffect("HasFood", false);
        cost = 0.1f;
    }
    public override bool Perform(WorldState state)
    {
        if (!done)
        {
            Debug.Log("Comer yum yum");
            state["IsSatisfied"] = true;
            state["HasFood"] = false;
            done = true;
        }
        return done;


    }

    public override bool IsDone()
    {
        return done;
    }
}
