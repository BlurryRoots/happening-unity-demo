using BlurryRoots.Happening;
using UnityEngine;

/// <summary>
/// Houses an instance of an event hub.
/// </summary>
public class EventHubSystem : MonoBehaviour {

    /// <summary>
    /// Event hub used to dispatch events.
    /// </summary>
    [Tooltip("Event hub used to dispatch events.")]
    public EventHub events = new EventHub ();

    /// <summary>
    /// Unity method called at the end of the game logic.
    /// </summary>
    void LateUpdate () {
        // Dispatch events at the end of the game logic when input, animation
        // and physics systems have updated the state of the game.
        this.events.DispatchAllRaisedEvents ();
    }

}
