using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon {

    bool shieldUp = false;

    void Start() {

    }

    protected override void GameUpdate() {
    }

    public override void PrimaryAction() {
        shieldUp = !shieldUp;
        if (shieldUp)
            gameObject.GetComponent<Animator>().Play("ShieldUp");
        else
            gameObject.GetComponent<Animator>().Play("ShieldDown");
    }

    public override void SecondaryAction() {
    }

    protected override void Blocked(Collision2D collision) {
    }
}
