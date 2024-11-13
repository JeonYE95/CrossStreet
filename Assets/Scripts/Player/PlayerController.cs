using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementtInput;

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
        Vector3 dir = transform.forward * curMovementtInput.y + transform.right * curMovementtInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    void Rotate()
    {
        Vector3 direction = new Vector3(curMovementtInput.x, 0, curMovementtInput.y);

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    private void UpdateAnimation()
    {
        bool isMoving = curMovementtInput != Vector2.zero;
        aniController.SetIsMoving(isMoving);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            curMovementtInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementtInput = Vector2.zero;
        }
    }
}
