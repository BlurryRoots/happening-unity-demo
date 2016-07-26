using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 2;
    
    void Awake () {
        this.body = this.GetComponent<Rigidbody> ();
    }
    
    void Update () {
        var x = Input.GetAxis ("Horizontal");
        var y = Input.GetAxis ("Vertical");

        this.body.AddForce (new Vector3 (x, 0, y) * this.speed);
    }

    private Rigidbody body;

}
