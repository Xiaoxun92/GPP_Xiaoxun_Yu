using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls player plane's movement
public class Player : MonoExtended {

    public float ACCELERATION;
    public float MOVE_SPEED_MAX;
    public float FRICTION;
    public float ROTATE_SPEED;

    Weapon weapon;
    Vector2 speed = new Vector2();
    WEAPON_TYPE currentWeapon;

    void Start() {
        currentWeapon = WEAPON_TYPE.SPEAR;
        weapon = transform.GetChild(0).GetComponent<Weapon>();
    }

    protected override void GameUpdate() {
        Combat();
        Movement();
    }

    void Combat() {
        if (Input.GetMouseButtonDown(0)) {
            if (weapon.ready)
                weapon.PrimaryAttack();
        }
    }

    void Movement() {
        // Movement controls
        Vector2 direction = new Vector2();
        if (Input.GetAxis("Horizontal") > 0) {
            direction.x = 1;
        } else if (Input.GetAxis("Horizontal") < 0) {
            direction.x = -1;
        }
        if (Input.GetAxis("Vertical") > 0) {
            direction.y = 1;
        } else if (Input.GetAxis("Vertical") < 0) {
            direction.y = -1;
        }

        // Move & rotate
        if (direction.magnitude > 0) {
            speed += direction.normalized * ACCELERATION * Time.deltaTime;
            if (speed.magnitude > MOVE_SPEED_MAX)
                speed = speed.normalized * MOVE_SPEED_MAX;
        } else {
            speed *= FRICTION;
        }
        transform.position += (Vector3)speed * Time.deltaTime;

        // Direction controls
        switch (currentWeapon) {
            case WEAPON_TYPE.SPEAR:
                if (weapon.lockDirection == false) {
                    Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    float targetAngle = BasicFunc.VectorToAngle(cameraPos - transform.position);
                    BasicFunc.TransformMoveTowardsAngle(transform, targetAngle, ROTATE_SPEED * Time.deltaTime);
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "EnemyWeapon")
            return;
        gameManager.gameState = 2;
        Destroy(gameObject);
    }
}
