using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {

    [SerializeField] GameObject red;

    protected override void GameUpdate() {
    }

    public override void PrimaryAction() {
        gameObject.GetComponent<Animator>().Play("SwordSlash");
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
