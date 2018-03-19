using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSpear : ExtendedMono {

    [SerializeField] bool isReady;
    public bool directionLock;

    void Start() {
    }

    protected override void GameUpdate() {
        if (isReady) {
            if (Input.GetAxis("Attack") > 0) {
                gameObject.GetComponent<Animator>().Play("Stab");
            }
        }
    }
}
