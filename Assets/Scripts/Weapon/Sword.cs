using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {

    protected override void GameUpdate() {
    }

    public override void PrimaryAttack() {
        gameObject.GetComponent<Animator>().Play("SwordSlash");
    }

    public override void SecondaryAttack() {
    }
}
