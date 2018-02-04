using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyBase {

    public float AIM_ANGLE;
    [SerializeField] GameObject arrowSprite;
    [SerializeField] GameObject arrowPrefab;

    [SerializeField] bool bowReady;

    new void Start() {
        base.Start();
    }

    void Update() {
        AIGeneral();
    }

    void AIGeneral() {
        if (bowReady)
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
        gameObject.GetComponent<Animator>().Play("Reload");
        Instantiate(arrowPrefab, arrowSprite.transform.position, arrowSprite.transform.rotation);
    }

    void Move() {

    }
}
