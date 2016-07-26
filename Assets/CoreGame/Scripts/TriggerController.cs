using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

    void OnTriggerEnter (Collider other) {
        Debug.Log ("Entered trigger; raising event.");

        FindObjectOfType<EventHubSystem> ().events.Raise (new TriggerEntered () {
            collider = other,
        });
    }

}
