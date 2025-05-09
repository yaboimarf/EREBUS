using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Vector3 moveDir;
    public float moveSpeed;
    public Transform cam;
    public Vector3 bodyRotate;
    public Vector3 camRotate;
    public float rotateSpeed;
    public Rigidbody rb;
    public float jumpHeight;
    public float groundedDistance;
    public RaycastHit groundedHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BodyMovement();
        CamMovement();
        Jump();
    }
    public void BodyMovement()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        transform.Translate(moveDir * Time.deltaTime * moveSpeed);
    }
    public void CamMovement()
    {
        bodyRotate.y = Input.GetAxis("Mouse X");
        camRotate.x = -Input.GetAxis("Mouse Y");

        transform.Rotate(bodyRotate * Time.deltaTime * rotateSpeed);
        cam.Rotate(camRotate * Time.deltaTime * rotateSpeed);
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(transform.position, -transform.up, out groundedHit, groundedDistance))
            {
                rb.velocity = (Vector3.up * jumpHeight);
            }
        }
    }
}
