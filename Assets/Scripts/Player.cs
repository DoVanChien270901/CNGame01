using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moveInput;
    private Animator animator;

    private bool isRoll = false;
    public float rollSpeed;
    public float rollTime;
    private float timingRoll;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        handleRoll();
        handleRun();
    }

    private void handleRun() {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        animator.SetFloat("speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
        }
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    private void handleRoll() {
        if (Input.GetKeyDown(KeyCode.Space) && isRoll == false)
        {
            isRoll = true;
            moveSpeed += rollSpeed;
            timingRoll = rollTime;
            animator.SetBool("isRoll", isRoll);
        }

        if (timingRoll <= 0 && isRoll)
        {
            moveSpeed -= rollSpeed;
            isRoll = false;
            animator.SetBool("isRoll", isRoll);
        }
        else {
            timingRoll -= Time.deltaTime;
        }
    }
}
