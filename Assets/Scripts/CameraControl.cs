using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float horizontalSens = 50f;
    private float verticalSens = 50f;
    private float xBorder = 15f;
    private float zDownBorder = -75f;
    private float zUpBorder = -10f;
    float horizontalInput;
    float verticalInput;
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        MoveCamera();
    }
    void MoveCamera()
    {
        Vector3 direction = new Vector3(horizontalInput * horizontalSens, 0, verticalInput * verticalSens);
        transform.position += direction * Time.deltaTime;
        if (transform.position.z < zDownBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zDownBorder);
        }
        if (transform.position.z > zUpBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpBorder);
        }
        if (transform.position.x < -xBorder)
        {
            transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBorder)
        {
            transform.position = new Vector3(xBorder, transform.position.y, transform.position.z);
        }
    }
}
