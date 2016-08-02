using UnityEngine;
using BlurryRoots.Happening;

/// <summary>
/// Component used to fire TriggerEntered events.
/// </summary>
public class TriggerController : MonoBehaviour {

    /// <summary>
    /// List of tags triggering this trap.
    /// </summary>
    [Tooltip ("List of tags triggering this trap.")]
    public string[] triggeringTags;

    /// <summary>
    /// Unity method, called before this component is first being updated.
    /// </summary>
    void Start () {
        // Initialize the event hub reference.
        var hubSystem = FindObjectOfType<EventHubSystem> ();
        this.eventHub = hubSystem.events;

    }

    /// <summary>
    /// Unity callback, invoked when collider enters a trigger attached to the
    /// game object holding this component.
    /// </summary>
    /// <param name="other">Collider entering this trigger.</param>
    void OnTriggerEnter (Collider other) {
        // Check if the gameobject holding the collider is contained in
        // the list of triggering tags.
        var reactToTarget = false;
        var targetTag = other.gameObject.tag;
        for (var i = 0; i < this.triggeringTags.Length; ++i) {
            if (targetTag == this.triggeringTags[i]) {
                reactToTarget = true;
            }
        }

        // If it is contained within the list, raise the entered event.
        if (reactToTarget) {
            this.eventHub.Raise (new TriggerEntered () {
                trigger = this,
                collider = other,
            });
        }
    }

    /// <summary>
    /// Reference to the event hub.
    /// </summary>
    private EventHub eventHub;

}
