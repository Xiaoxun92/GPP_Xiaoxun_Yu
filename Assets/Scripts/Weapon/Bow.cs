using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon {

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowTransform;

    string tag;

    public override void SetTag(string t) {
        tag = t;
    }

    protected override void GameUpdate() {
    }

    public override void PrimaryAttack() {
        GameObject newArrow = Instantiate(arrowPrefab, arrowTransform.position, arrowTransform.rotation);
        newArrow.tag = tag;
        gameObject.GetComponent<Animator>().Play("Reload");
    }

    public override void SecondaryAttack() {
    }
}
