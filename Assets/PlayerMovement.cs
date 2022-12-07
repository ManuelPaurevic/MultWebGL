using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 playerInput;
    private Transform playerY;
    private Vector3 mousePosition;
    private Rigidbody rb;
    private Camera cam;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        playerY = this.transform;
    }

    Plane plane = new Plane(Vector3.down, 0);
   
    private void Update() {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        mousePosition = Input.mousePosition;
    }

    private void FixedUpdate() {
        HandleMovement();
        Rotation();
    }

    #region Movement

    [SerializeField] private float acceleration = 50;

    private void HandleMovement() {
        rb.velocity += new Vector3(playerInput.x * acceleration * Time.deltaTime, 0 ,playerInput.z * acceleration * Time.deltaTime).normalized;
    }

    #endregion

    #region Rotation

    Ray ray;
    Vector3 lookPosition;
    private void Rotation(){
        ray = Camera.main.ScreenPointToRay(mousePosition);
        if(plane.Raycast(ray, out float distance)){
            lookPosition = ray.GetPoint(distance);
        }
        transform.LookAt(lookPosition);
    }


    #endregion
}
