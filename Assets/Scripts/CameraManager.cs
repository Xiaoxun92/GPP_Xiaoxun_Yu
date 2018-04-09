using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] Transform player;
    [SerializeField] float MOVE_LERP;
    [SerializeField] float ROTATE_LERP;

    void Start() {

    }

    void Update() {
        if (player == null)
            return;
        transform.position = Vector2.Lerp(transform.position, player.position, MOVE_LERP);
        transform.position += new Vector3(0, 0, -10);
        float angle = Mathf.LerpAngle(transform.eulerAngles.z, player.eulerAngles.z, ROTATE_LERP);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
