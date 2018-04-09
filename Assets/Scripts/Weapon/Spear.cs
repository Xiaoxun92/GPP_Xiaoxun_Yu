using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon {

    [SerializeField] GameObject red;

    protected override void GameUpdate() {
    }

    public override void PrimaryAction() {
        gameObject.GetComponent<Animator>().Play("Stab");
    }

    public override void SecondaryAction() {
    }

    protected override void Blocked(Collision2D collision) {
        DeactiveRed();
    }

    public void ActiveRed() {
        red.SetActive(true);
    }

    public void DeactiveRed() {
        red.SetActive(false);
    }
}
