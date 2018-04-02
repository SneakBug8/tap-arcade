using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2[] RelativePoints;
    int curPoint = 0;
    public float[] Rotation;
    int curRotation = 0;
    public float Speed;
    public float RotationSpeed;
    private void OnDrawGizmosSelected()
    {
        if (AbsolutePoints != null)
        {
            Vector2 lastpoint = transform.position;
            foreach (var point in AbsolutePoints)
            {
                Gizmos.DrawWireCube(point, new Vector3(1, 1, 0));
                Gizmos.DrawLine(lastpoint, point);
                lastpoint = point;
            }
        }
    }

    #region RelativePoints
    public Vector2[] AbsolutePoints {
        get {
            if (_absolutePoints == null) {
                _absolutePoints = AbsoluteVectors(RelativePoints);
            }

            return _absolutePoints;
        }
    }

    Vector2[] _absolutePoints;

    Vector2[] AbsoluteVectors(Vector2[] vectors) {
        var result = new Vector2[vectors.Length];

        for (int i = 0; i < vectors.Length; i++) {
            result[i] = transform.position + (Vector3) vectors[i];
        }

        return result;
    }

    #endregion

    private void Update() {
        Move(LevelController.Global.deltaY, Time.deltaTime);
        Rotate();

        if (transform.position.y > 20) {
            Destroy(gameObject);
        }
    }

    public void Move(float deltaY, float deltaTime)
    {
        transform.position -= new Vector3(0, deltaY , 0);
		
        if (AbsolutePoints.Length > 0)
        {
            for (int i = 0; i < AbsolutePoints.Length; i++)
            {
                AbsolutePoints[i] -= new Vector2(0, deltaY);
            }

            transform.position = Vector2.MoveTowards(transform.position, AbsolutePoints[curPoint], Speed * deltaTime);

            if (Vector2.Distance(transform.position, AbsolutePoints[curPoint]) <= 0.5f)
            {
                curPoint = (curPoint + 1) % AbsolutePoints.Length;
            }
        }
    }

    public void Rotate() {
        if (Rotation.Length > 0)
        {
            var targetRotation = Quaternion.Euler(0, 0, Rotation[curRotation]);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed);

            if (transform.rotation == targetRotation)
            {
                curRotation = (curRotation + 1) % Rotation.Length;
            }
        }
        else if (Rotation.Length == 0 && RotationSpeed != 0)
        {
            var curAngle = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(curAngle.x, curAngle.y, curAngle.z + RotationSpeed);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Player.Global.gameObject)
        {
            LevelController.Global.OnLose();
        }
    }
}
