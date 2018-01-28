using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float LIFETIME;
    public float SPEED;
    public float Y_OFFSET;

    public float currentLifetime;
    public float currnetSpeed;
    public float direction;
    
	void Start () {
        currentLifetime = LIFETIME;
        currnetSpeed = SPEED;

        Vector3 deltaPos = new Vector3(-Mathf.Sin(direction * Mathf.Deg2Rad), Mathf.Cos(direction * Mathf.Deg2Rad));
        transform.position += deltaPos * Y_OFFSET;
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, direction));
    }
	
	void Update () {
		
	}

    void FixedUpdate() {
        currentLifetime -= Time.fixedDeltaTime;
        if (currentLifetime < 0)
            Destroy(gameObject);

        Vector3 deltaPos = new Vector3(-Mathf.Sin(direction * Mathf.Deg2Rad), Mathf.Cos(direction * Mathf.Deg2Rad));
        transform.position += deltaPos * currnetSpeed * Time.fixedDeltaTime;
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, direction));
    }
}
