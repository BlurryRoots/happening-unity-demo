using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {

    public float speed = 2;
    public Transform openPosition;

    void Start () {
        FindObjectOfType<EventHubSystem> ().events.Subscribe<TriggerEntered> (
            this.OnTrapTriggerEntered
        );
    }

    private void OnTrapTriggerEntered (TriggerEntered e) {
        Debug.Log ("Got trigger entered event " + e);
        if (false == this.isOpen) {
            StartCoroutine (this.OpenTrapMount ());
            this.isOpen = true;
        }
    }

    private IEnumerator OpenTrapMount () {
        var t = 0f;
        var startPos = this.transform.position;
        var endPos = this.openPosition.position;

        while (1f > t) {
            this.transform.position = Vector3.Lerp (startPos, endPos, t);
            t += Time.deltaTime * speed;

            yield return null;
        }

        this.transform.position = endPos;
    }

    private bool isOpen;

}
