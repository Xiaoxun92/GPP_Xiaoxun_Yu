using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyBase {

    [SerializeField] float MAX_DISTANCE;
    [SerializeField] float AIM_SHIFT_RANGE;

    Node<EnemyArcher> behaviorTreeRoot;
    float aimAngleShift;

    new void Start() {
        base.Start();
        GameObject weaponObject = Instantiate(weaponPrefab, transform);
        weapon = weaponObject.GetComponent<Weapon>();
        weapon.SetFriendly(false);
        aimAngleShift = Random.Range(-AIM_SHIFT_RANGE, AIM_SHIFT_RANGE);
    }

    protected override void InitBehaviorTree() {

        behaviorTreeRoot = new NodeSelector<EnemyArcher>(

            // If player is out of range, move closer
            new NodeSequence<EnemyArcher>(
                new OutOfRange(),
                new MoveToPlayer(),
                new Aim()),

            // If player is in range, engage
            new NodeSequence<EnemyArcher>(

                new IsWeaponReady(),
                new Aim(),
                new IsAimed(),
                new Shoot()));
    }

    protected override void GameUpdate() {
        behaviorTreeRoot.BTUpdate(this);
    }

    class OutOfRange : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            return (context.transform.position - context.player.transform.position).magnitude > context.MAX_DISTANCE;
        }
    }

    class MoveToPlayer : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            Vector3 targetPos = context.player.transform.position;
            float distance = context.MOVE_SPEED * context.deltaTime;
            context.transform.position = Vector3.MoveTowards(context.transform.position, targetPos, distance);
            return true;
        }
    }

    class IsAimed : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            float targetAngle = context.GetPlayerDirection() + context.aimAngleShift;
            return Mathf.Abs(context.transform.eulerAngles.z - targetAngle) < 1;
        }
    }

    class Aim : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            float targetAngle = context.GetPlayerDirection() + context.aimAngleShift;
            BasicFunc.RotateTowardsAngle(context.transform, targetAngle, context.ROTATE_SPEED * context.deltaTime);
            return true;
        }
    }

    class IsWeaponReady : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            return context.weapon.ready;
        }
    }

    class Shoot : Node<EnemyArcher> {
        public override bool BTUpdate(EnemyArcher context) {
            context.weapon.PrimaryAction();
            // Set the next aim angle shift
            context.aimAngleShift = Random.Range(-context.AIM_SHIFT_RANGE, context.AIM_SHIFT_RANGE);
            return true;
        }
    }
}
