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
        deltaPos = BasicFunc.AngleToVector(transform.eulerAngles.z) * SPEED;
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
