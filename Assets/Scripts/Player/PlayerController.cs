using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody _rigidbody;
    private AnimationController aniController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        aniController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        UpdateAnimation();
    }

    void Move()
    {
        Vector3 dir = Vector3.zero;

        if (curMovementInput.y > 0) 
        {
            dir = Vector3.forward;
        }
        else if (curMovementInput.y < 0) 
        {
            dir = Vector3.back;
        }

        if (curMovementInput.x < 0) 
        {
            dir = Vector3.left;
        }
        else if (curMovementInput.x > 0) 
        {
            dir = Vector3.right;
        }

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);

            Vector3 velocity = dir * moveSpeed;
            velocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = velocity;
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        }
    }

    private void UpdateAnimation()
    {
        bool isMoving = curMovementInput != Vector2.zero;
        aniController.SetIsMoving(isMoving);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }
}
