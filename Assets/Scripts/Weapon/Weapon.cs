using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoExtended {

    public bool ready = true;
    public bool lockDirection = false;

    public abstract void SetTag(string tag);

    public abstract void PrimaryAttack();

    public abstract void SecondaryAttack();
}
