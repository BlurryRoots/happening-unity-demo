using UnityEngine;
using System.Collections;

/// <summary>
/// Component controlling the beam holding the trap.
/// </summary>
public class TrapController : MonoBehaviour {

    /// <summary>
    /// Speed with which the beam will move out of the way.
    /// </summary>
    [Tooltip ("Speed with which the beam will move out of the way.")]
    public float speed = 2;
    /// <summary>
    /// Position to which the beam will move towards.
    /// </summary>
    [Tooltip ("Position to which the beam will move towards.")]
    public Transform openPosition;

    /// <summary>
    /// Unity method, called before this component is first being updated.
    /// </summary>
    void Start () {
        // Register for TriggerEntered events.
        var hubSystem = FindObjectOfType<EventHubSystem> ();
        hubSystem.events.Subscribe<TriggerEntered> (
            this.OnTrapTriggerEntered
        );
    }

    /// <summary>
    /// Callback getting called if player triggers the trap.
    /// </summary>
    /// <param name="e"></param>
    private void OnTrapTriggerEntered (TriggerEntered e) {
        Debug.Log (string.Format ("Trap controller got a {0} event.", e));

        // If the door has not already been opened,
        if (this.isOpen) {
            return;
        }

        // open it!
        this.isOpen = true;
        this.StartCoroutine (this.OpenTrapMount ());
    }

    /// <summary>
    /// Coroutine opening the mount holding the trap cube.
    /// </summary>
    /// <returns>Current coroutine state.</returns>
    private IEnumerator OpenTrapMount () {
        var t = 0f;
        var startPos = this.transform.position;
        var endPos = this.openPosition.position;

        // Move the mount until it reaches its end position.
        while (1f > t) {
            this.transform.position = Vector3.Lerp (startPos, endPos, t);
            t += Time.deltaTime * speed;

            yield return null;
        }

        // Set the position of the mount to end at the designated endPos.
        this.transform.position = endPos;
    }

    /// <summary>
    /// Field indicating if the trap mount is open or closed.
    /// </summary>
    private bool isOpen;

}
