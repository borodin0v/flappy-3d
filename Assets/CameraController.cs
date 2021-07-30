using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private float x;
         private float y;
     private Vector3 rotateValue;
    [SerializeField] float mouseSensitivity = 2f;
     void Update()
     {
         y = Input.GetAxis("Mouse X") * mouseSensitivity;
         x = Input.GetAxis("Mouse Y") * mouseSensitivity;
         rotateValue = new Vector3(x, y * -1, 0);
         transform.eulerAngles -= rotateValue;
     }
}
