using System.Collections.Generic;

/// <summary>
/// Definimos el objetivo que se desea alcanzar,
/// Tiene nombre, prioridad y estado (world snap).
/// </summary>

public class GOAPGoal
{
    public string name;
    public Dictionary<string, object> DesiredState;
    public float priority;

    public GOAPGoal(string name, float priority)
    {
        this.name = name;
        this.priority = priority;
        DesiredState = new Dictionary<string, object>();
    }
}
