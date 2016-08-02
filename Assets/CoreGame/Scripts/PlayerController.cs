using UnityEngine;
using System.Collections;

/// <summary>
/// Component used to control the player character.
/// </summary>
public class PlayerController : MonoBehaviour {

    /// <summary>
    /// Movement speed.
    /// </summary>
    [Tooltip ("Force used to push player character.")]
    public float pushForce = 512;
    
    /// <summary>
    /// Unity method, called when component is being initialized.
    /// </summary>
    void Awake () {
        this.body = this.GetComponent<Rigidbody> ();
    }
    
    /// <summary>
    /// Unity method, called every update loop as fast as possible.
    /// </summary>
    void Update () {
        // Fetch input values for horizontal and vertical axes.
        var x = Input.GetAxis ("Horizontal");
        var y = Input.GetAxis ("Vertical");

        // Create a vector representing the desired movement.
        var movementVector = new Vector3 (x, 0, y);
        var modifier = Time.deltaTime * this.pushForce;

        // Add a force to the player characters rigid body so it moves.
        this.body.AddForce (modifier * movementVector);
    }

    /// <summary>
    /// Reference to the rigid body component used by the player character.
    /// </summary>
    private Rigidbody body;

}
