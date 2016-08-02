using UnityEngine;
using System.Collections;
using BlurryRoots.Happening;

/// <summary>
/// Component used to control a paddle trap.
/// </summary>
public class PaddleController : MonoBehaviour {

    /// <summary>
    /// Force used to swing paddle.
    /// </summary>
    [Tooltip ("Force used to swing paddle.")]
    public float force = 1000;
    /// <summary>
    /// Time to way for the paddle to swing.
    /// </summary>
    [Tooltip ("Time to way for the paddle to swing.")]
    public float triggerDelay = 0.618f;

    /// <summary>
    /// Unity method, called before this component is first being updated.
    /// </summary>
    void Start () {
        // Get phyiscs references.
        this.body = this.GetComponent<Rigidbody> ();
        this.joint = this.GetComponent<HingeJoint> ();

        // Get event hub reference.
        var hubSystem = FindObjectOfType<EventHubSystem> ();
        hubSystem.events.Subscribe<TriggerEntered> (this.OnTriggerEntered);
    }

    /// <summary>
    /// Callback, invoked when a trigger is entered.
    /// </summary>
    /// <param name="e"></param>
    void OnTriggerEntered (TriggerEntered e) {
        // If paddle has not yet been activated,
        if (this.isActivated) {
            return;
        }

        // swing it!
        this.isActivated = true;
        this.StartCoroutine (this.SwingPaddle ());
    }

    /// <summary>
    /// Coroutine, used to swing the paddle.
    /// </summary>
    /// <returns>Current coroutine state.</returns>
    IEnumerator SwingPaddle () {
        // Wait a specified time, before swinging.
        yield return new WaitForSeconds (this.triggerDelay);

        // Swing the paddle by adding a force from the bottom.
        var forceVector = this.force * new Vector3 (0, 1, 0);
        var position = this.transform.position;
        this.body.AddForceAtPosition (forceVector, position);
    }

    /// <summary>
    /// Reference to the paddles rigid body.
    /// </summary>
    private Rigidbody body;
    /// <summary>
    /// Reference to the paddles joint.
    /// </summary>
    private HingeJoint joint;
    /// <summary>
    /// Field indicating if the paddle has been activated.
    /// </summary>
    private bool isActivated;

}
