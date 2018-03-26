using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpearman : EnemyBase {

    public float AIM_ANGLE;

    [SerializeField] float MOVE_TIME_MAX;
    [SerializeField] float MOVE_TIME_MIN;
    [SerializeField] float WAIT_TIME_MAX;
    [SerializeField] float WAIT_TIME_MIN;
    float moveTimer = 0;     // moveTimer > 0: moving   moveTimer <= 0: waiting

    [SerializeField] float ATTACK_RANGE_MAX;
    [SerializeField] float ATTACK_RANGE_MIN;
    Vector3 moveSpeed;

    protected override void Start() {
        base.Start();
        GameObject weaponObject = Instantiate(weaponPrefab, transform);
        weapon = weaponObject.GetComponent<Weapon>();
        weapon.SetTag(GameConst.TAG_ENEMY_WEAPON);
    }

    protected override void GameUpdate() {
        AIGeneral();
    }

    void AIGeneral() {
        Move();
        if (weapon.ready)
            Attack();
    }

    void Move() {
        if (weapon.lockDirection)
            return;

        // Waiting
        if (moveTimer <= 0) {
            moveTimer += Time.deltaTime;
            // Set new movement
            if (moveTimer > 0) {
                moveTimer = Random.Range(MOVE_TIME_MAX, MOVE_TIME_MIN);
                if (GetPlayerDistance() >= (ATTACK_RANGE_MAX + ATTACK_RANGE_MIN) / 2)
                    moveSpeed = BasicFunc.AngleToVector(GetPlayerDirection()) * MOVE_SPEED;
                else
                    moveSpeed = -BasicFunc.AngleToVector(GetPlayerDirection()) * MOVE_SPEED;
            }
            return;
        }

        // Moving
        moveTimer -= Time.deltaTime;
        // Wait for a while
        if (moveTimer <= 0) {
            moveTimer = -Random.Range(WAIT_TIME_MAX, WAIT_TIME_MIN);
            return;
        }
        // Continue moving
        transform.position += moveSpeed * Time.deltaTime;
        BasicFunc.TransformMoveTowardsAngle(transform, GetPlayerDirection(), ROTATE_SPEED * Time.deltaTime);
    }

    void Attack() {
        if (Mathf.Abs(transform.eulerAngles.z - GetPlayerDirection()) < AIM_ANGLE) {
            if (GetPlayerDistance() < ATTACK_RANGE_MAX && GetPlayerDistance() > ATTACK_RANGE_MIN)
                weapon.PrimaryAttack();
        }
    }
}
