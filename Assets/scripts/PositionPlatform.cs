using UnityEngine;
using System.Collections;

public class PositionPlatform : MonoBehaviour
{


    private float smooth = 5.0F;
    public int rotaitonZ = 90;
    public float targetAngleZ = 0;
    public int indexPivot = 0;
    private Quaternion target;
    private Quaternion pivot;
    public bool isAnimed = false;

    // Use this for initialization
    void Start()
    {
        target = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("up") && !isAnimed)
        {
            isAnimed = true;
        }

        if (isAnimed)
        {
            target = Quaternion.Euler(0, 0, rotaitonZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }
        targetAngleZ = transform.rotation.eulerAngles.z;
        if (rotaitonZ >= 359)
        {
            rotaitonZ = 0;
        }

        if (targetAngleZ <= (rotaitonZ + 1) && targetAngleZ >= (rotaitonZ - 1))
        {
            isAnimed = false;
            Debug.Log(rotaitonZ);
            if (rotaitonZ == 0 )
            {
                rotaitonZ = 90;
            }
            else {

                rotaitonZ += 90;
            }
        }
    }
}
