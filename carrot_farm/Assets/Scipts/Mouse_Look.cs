using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    public float mouseSensitivity = 100f; //sensitivity level
    public Transform playerBody; // player body object
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // getting x and y input axis. multiplying by our mouse sensitivity and time.deltatime so framerate doesn't affect movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // rotate body of player on y axis based on sensitivity so can look left/right
        playerBody.Rotate(Vector3.up * mouseX);
        
        //rotate bodyof player up and down around x axis
        xRotation -= mouseY; //decreasing instead of increasing because otherwise it flips controls
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //preventing over-rotating
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //keeping track of rotation and rotating object

    }
}
