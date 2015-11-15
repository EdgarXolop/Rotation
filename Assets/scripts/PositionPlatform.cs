using UnityEngine;
using System.Collections;

public class PositionPlatform : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public float distance = 5f;
    public Vector3 pivot = new Vector3(0f, 6.73f, 30f);
    private float currentYAngle = 0f;
    private float targetYAngle = 90f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentYAngle = Mathf.MoveTowardsAngle(currentYAngle, targetYAngle, rotationSpeed * Time.deltaTime);

        /*transform.position = new Vector3(
            pivot.x + Mathf.Sin(currentYAngle * Mathf.Deg2Rad) * distance,
            transform.position.z,
            pivot.z + Mathf.Cos(currentYAngle * Mathf.Deg2Rad) * distance
        );*/

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
             pivot.z + Mathf.Cos(currentYAngle * Mathf.Deg2Rad) * distance
        );
    }
}
