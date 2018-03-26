using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoExtended {

    public bool ready = true;
    public bool lockDirection = false;

    protected bool isFriendly;

    public void SetFriendly(bool f) {
        isFriendly = f;
        if (isFriendly)
            gameObject.layer = (int)LAYER.FRIENDLY_WEAPON;
        else
            gameObject.gameObject.layer = (int)LAYER.ENEMY_WEAPON;
    }

    public virtual void PrimaryAttack() { }

    public virtual void SecondaryAttack() { }

    protected virtual void OnCollisionEnter2D(Collision2D collision) {
        if (gameObject.layer == (int)LAYER.ENEMY_WEAPON && collision.gameObject.layer == (int)LAYER.FRIENDLY_WEAPON) {
            Blocked();
        }
    }

    protected virtual void Blocked() { }
}
