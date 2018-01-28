using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player plane's movement
public class PlayerControl : MonoBehaviour
{

    public float SPEED_MIN, SPEED_MAX;
    public float ACCELERATION;
    public float TURNING_RATE;

    float speed;
    float direction;

    void Start() {
        speed = SPEED_MIN;
        direction = 0;
    }

    void Update() {

    }

    private void FixedUpdate() {
        // Check controls
        if (Input.GetKey(KeyCode.UpArrow)) {
            speed += ACCELERATION * Time.fixedDeltaTime;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            speed -= ACCELERATION * Time.fixedDeltaTime;
        }
        speed = Mathf.Clamp(speed, SPEED_MIN, SPEED_MAX);

        if (Input.GetKey(KeyCode.LeftArrow)) {
            direction += TURNING_RATE * Time.fixedDeltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            direction -= TURNING_RATE * Time.fixedDeltaTime;
        }

        Vector3 deltaPos = new Vector3(-Mathf.Sin(direction * Mathf.Deg2Rad), Mathf.Cos(direction * Mathf.Deg2Rad));
        transform.position += deltaPos * speed * Time.fixedDeltaTime;
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, direction));
    }
}
