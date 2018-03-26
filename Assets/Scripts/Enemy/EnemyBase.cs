using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoExtended {

    [SerializeField] protected GameObject weaponPrefab;
    protected Weapon weapon;

    public int HP;
    public float MOVE_SPEED;
    public float ROTATE_SPEED;
    public float REACTION_TIME = 0.3f;

    protected GameObject player;

    protected virtual void Start() {
        player = GameObject.FindWithTag("Player");
    }

    protected override void GameUpdate() {
    }

    // Hit by the player
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != (int)LAYER.FRIENDLY_WEAPON)
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
