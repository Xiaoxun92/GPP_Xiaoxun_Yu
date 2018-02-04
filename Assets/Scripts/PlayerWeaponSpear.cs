using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSpear : MonoBehaviour {

    [SerializeField] bool isReady;

    void Start() {
    }

    void Update() {
        if (isReady) {
            if (Input.GetAxis("Attack") > 0) {
                gameObject.GetComponent<Animator>().Play("Stab");
            }
        }
    }
}
