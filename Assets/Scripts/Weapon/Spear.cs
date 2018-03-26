﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon {

    protected override void GameUpdate() {
    }

    public override void SetTag(string tag) {
        transform.GetChild(0).GetChild(0).tag = tag;
    }

    public override void PrimaryAttack() {
        gameObject.GetComponent<Animator>().Play("Stab");
    }

    public override void SecondaryAttack() {
    }
}