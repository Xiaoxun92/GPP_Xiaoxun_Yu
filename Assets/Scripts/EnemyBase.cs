using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoExtended {

    [SerializeField] protected GameObject weaponPrefab;
    protected Weapon weapon;

    public float MOVE_SPEED;
    public float ROTATE_SPEED;

    protected GameObject player;

    protected virtual void Start() {
        player = GameObject.FindWithTag(GameConst.TAG_PLAYER);
    }

    protected override void GameUpdate() {
    }

    // Hit by the player
    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != GameConst.TAG_PLAYER_WEAPON)
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
