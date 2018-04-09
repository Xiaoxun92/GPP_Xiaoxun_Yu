using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyBase {

    public float AIM_ANGLE;

    new void Start() {
        base.Start();
        GameObject weaponObject = Instantiate(weaponPrefab, transform);
        weapon = weaponObject.GetComponent<Weapon>();
        weapon.SetFriendly(false);
    }

    protected override void GameUpdate() {
        AIGeneral();
    }

    void AIGeneral() {
        if (weapon.ready)
            Attack();
        Move();
    }

    void Attack() {
        // Aim
        if (Mathf.Abs(transform.eulerAngles.z - GetPlayerDirection()) > AIM_ANGLE) {
            BasicFunc.TransformMoveTowardsAngle(transform, GetPlayerDirection(), ROTATE_SPEED * Time.deltaTime);
            return;
        }

        // Shoot arrow
        weapon.PrimaryAction();
    }

    void Move() {

    }
}
