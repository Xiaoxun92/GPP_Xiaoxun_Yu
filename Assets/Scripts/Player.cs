using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls player plane's movement
public class Player : MonoExtended {

    [SerializeField] float ACCELERATION;
    [SerializeField] float MOVE_SPEED_MAX;
    [SerializeField] float FRICTION;
    [SerializeField] float ROTATE_SPEED;
    [SerializeField] GameObject Spear;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject Shield;

    Weapon weaponPrimary;
    Weapon weaponSecondary;
    Vector2 speed = new Vector2();
    WEAPON_TYPE currentWeapon;

    void Start() {
        currentWeapon = WEAPON_TYPE.SPEAR;
        weaponPrimary = Spear.GetComponent<Weapon>();
        weaponSecondary = Shield.GetComponent<Weapon>();
    }

    protected override void GameUpdate() {
        if (weaponPrimary.ready && Input.GetKeyDown(KeyCode.L)) {
            if (Spear.activeSelf) {
                weaponPrimary = Sword.GetComponent<Weapon>();
                Spear.SetActive(false);
                Sword.SetActive(true);
            } else {
                weaponPrimary = Spear.GetComponent<Weapon>();
                Spear.SetActive(true);
                Sword.SetActive(false);
            }
        }

        Combat();
        Movement();
    }

    void Combat() {
        if (Input.GetKeyDown(KeyCode.K)) {
            if (weaponPrimary.ready)
                weaponPrimary.PrimaryAction();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            if (weaponSecondary.ready)
                weaponSecondary.PrimaryAction();
        }
    }

    void Movement() {
        // Handle controls
        Vector2 direction = new Vector2();
        int rotation = 0;
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

        if (Input.GetAxis("Rotate") > 0) {
            rotation = 1;
        } else if (Input.GetAxis("Rotate") < 0) {
            rotation = -1;
        }

        // Rotate
        transform.Rotate(0, 0, rotation * ROTATE_SPEED * Time.deltaTime);

        // Move & rotate
        if (direction.magnitude > 0) {
            speed += direction.normalized * ACCELERATION * Time.deltaTime;
            if (speed.magnitude > MOVE_SPEED_MAX)
                speed = speed.normalized * MOVE_SPEED_MAX;
        } else {
            speed *= FRICTION;
        }
        transform.position += (Vector3)transform.TransformVector(speed) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer != (int)LAYER.ENEMY_WEAPON)
            return;
        gameManager.gameState = 2;
        Destroy(gameObject);
    }
}
