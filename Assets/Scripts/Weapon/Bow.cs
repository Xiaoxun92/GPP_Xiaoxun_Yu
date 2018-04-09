using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowTransform;

    protected override void GameUpdate() {
    }

    public override void PrimaryAction() {
        GameObject newArrow = Instantiate(arrowPrefab, arrowTransform.position, arrowTransform.rotation);
        newArrow.GetComponent<Weapon>().SetFriendly(isFriendly);
        gameObject.GetComponent<Animator>().Play("Reload");
    }

    public override void SecondaryAction() {
    }

    protected override void Blocked() {
    }
}
