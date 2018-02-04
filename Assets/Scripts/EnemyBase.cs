using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public float MOVE_SPEED;
    public float ROTATE_SPEED;

    protected GameObject player;

    protected void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void Update() {

    }

    // Hit by the player
    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "PlayerWeapon")
            return;
        Destroy(gameObject);
    }

    protected float GetPlayerDirection() {
        return BasicFunc.VectorToAngle(player.transform.position - transform.position);
    }

    protected float GetPlayerDistance() {
        Vector3 delta = player.transform.position - transform.position;
        return delta.magnitude;
    }
}
