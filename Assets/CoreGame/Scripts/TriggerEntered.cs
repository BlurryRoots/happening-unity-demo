using UnityEngine;

/// <summary>
/// Event used when an object enteres a trigger.
/// </summary>
public struct TriggerEntered {

    /// <summary>
    /// Trigger which spawned this event.
    /// </summary>
    public TriggerController trigger;

    /// <summary>
    /// Collider entering the trigger.
    /// </summary>
    public Collider collider;

}
