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
    
    public static void RotateTowardsAngle(Transform t, float target, float maxDelta) {
        float angle = Mathf.MoveTowardsAngle(t.eulerAngles.z, target, maxDelta);
        t.eulerAngles = new Vector3(0, 0, angle);
    }
}
