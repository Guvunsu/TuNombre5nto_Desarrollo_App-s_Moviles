using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Aqui definimos la acciones.Cada accion tiene:
/// - Costo:
/// - Precondiciones (que debe de estar sucediendo para poder accionar).
/// - Efectos (lo que cambia del agente y del mundo ).
/// </summary>
public abstract class GOAPAction : MonoBehaviour
{
    public float cost = 1f;

    protected Dictionary<string, object> preconditions = new Dictionary<string, object>();
    protected Dictionary<string, object> effects = new Dictionary<string, object>();

    public Dictionary<string, object> Preconditions => preconditions;
    public Dictionary<string, object> Effects => effects;
    

    protected void AddPrecondition(string key, object value)
    {
        preconditions[key] = value;
    }

    protected void AddEffect(string key, object value)
    {
        effects[key] = value;
    }

    // Vamos a evaluar si, ddo el estado del mundo, podemos ejecutar la acción.
    public bool ArePreconditionsMet(WorldState state)
    {
        foreach(var condition in preconditions)
        {
            if(!state.ContainsKey(condition.Key))
                return false;

            if (!state[condition.Key].Equals(condition.Value))
                return false;
        }
        return true;                                             
    }

    // Despues definimos paraa cada acción sus "acciones" (moverse, animar, etc).
    public abstract bool Perform(WorldState state);
    // Nos avisa si ya se actualizó
    public abstract bool IsDone();

}
