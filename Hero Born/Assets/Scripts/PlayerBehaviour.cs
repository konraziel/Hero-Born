using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Variables for movement constants and inputs
    public float MoveSpeed = 10f;
    public float RotateSpeed = 85f;
    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer; // We will use this to determine when the player is allowed to jump
    private CapsuleCollider _col;
    void Start()
    {
        // On start, get our rigidbody and collider
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use the input class to set our player movement and rotation speeds
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;

        // Use OR assignment operator to check if the player is currently jumping or if the player is trying to jump. If either are true, _isJumping is also true
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        /*
         * We calculate the rotation based on our horizontal input, where we then create a quaternion in order to apply the rotation over delta time
         * We move the rigidbody based on vertical input also on delta time, and apply the calculated rotation to the rigidbody
         * Finally, we check if the character is on the ground and if a jump is triggered, if so then we add upwards force to replicate a jump
         */
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;

    }

    // Check if the player is currently on the ground using the Ground layer mask we made
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
