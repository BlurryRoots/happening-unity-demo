using BlurryRoots.Happening;
using UnityEngine;

public class EventHubSystem : MonoBehaviour {

    public EventHub events = new EventHub ();

    void LateUpdate () {
        this.events.DispatchAllRaisedEvents ();
    }

}
