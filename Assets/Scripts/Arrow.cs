using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    [SerializeField] float SPEED;
    [SerializeField] float RANGE;

    Vector3 startPos;
    Vector3 deltaPos;

    void Start () {
        startPos = transform.position;
        float angle = transform.eulerAngles.z * Mathf.Deg2Rad;
        deltaPos = new Vector2(-Mathf.Sin(angle), Mathf.Cos(angle)) * SPEED;
	}
	
	void Update () {
        transform.position += deltaPos * Time.deltaTime;
        if ((transform.position - startPos).magnitude >= RANGE)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "Player")
            return;
        Destroy(gameObject);
    }
}
