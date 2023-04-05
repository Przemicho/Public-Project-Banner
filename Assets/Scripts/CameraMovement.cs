using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     public float mouseSensitivity = 100;
     public float cameraSpeed = 1;

     private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          //getting mouse input
          float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
          float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
          //getting keybord input
          float x = Input.GetAxis("Horizontal");
          float z = Input.GetAxis("Vertical");

          if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
          {
               //setting rotation via mouse
               this.transform.Rotate(Vector3.down * mouseX);
               this.transform.Rotate(Vector3.right * mouseY);
               //prevents from rotation in z axis
               transform.rotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);

          }

          if (Input.GetKey(KeyCode.W))
          {
               this.transform.position += transform.forward * (cameraSpeed / 500);
          }
          else if (Input.GetKey(KeyCode.S))
          {
               this.transform.position -= transform.forward * (cameraSpeed / 500);
          }
          else if (Input.GetKey(KeyCode.D))
          {
               this.transform.position += transform.right * (cameraSpeed / 500);
          }else if (Input.GetKey(KeyCode.A))
          {
               this.transform.position -= transform.right * (cameraSpeed / 500);
          }
          
    }
}
