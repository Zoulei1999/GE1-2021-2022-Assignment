using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public Transform target; // target is the player 
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed; //Camero Rotate speed
    public Transform pivot;  // pivot is player attachment
    public float maxViewAngle; // used to prevent camera flipping up
    public float minViewAngle; // used to prevent camera flipping down
    public bool invertY;// used to invert camera controll


    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetValues){
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if(invertY){
            pivot.Rotate(vertical,0,0);
        } else {
            pivot.Rotate(-vertical,0,0);
        }

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f){
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0 ,0);
        } 
        if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle){
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0 ,0);
        }

        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngle,0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y){
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }

        transform.LookAt(target);
    }
}
