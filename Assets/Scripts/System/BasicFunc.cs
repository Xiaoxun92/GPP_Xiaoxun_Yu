using UnityEngine;
using System.Collections;

public static class BasicFunc {

    // 0 <= angle < 360
    public static float VectorToAngle(Vector2 v) {
        float angle = Vector2.SignedAngle(Vector2.up, v);
        if (angle < 0)
            angle += 360;
        return angle;
    }
    
    // Angle in degree
    public static Vector2 AngleToVector(float a) {
        return new Vector2(-Mathf.Sin(a * Mathf.Deg2Rad), Mathf.Cos(a * Mathf.Deg2Rad));
    }
    
    public static void TransformMoveTowardsAngle(Transform t, float target, float maxDelta) {
        float angle = t.eulerAngles.z;
        angle = Mathf.MoveTowardsAngle(angle, target, maxDelta);
        t.eulerAngles = new Vector3(0, 0, angle);
    }
}
