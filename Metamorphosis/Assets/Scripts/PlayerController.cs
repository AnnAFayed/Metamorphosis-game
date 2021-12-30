using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : MonoBehaviour,ISavable
{

    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public LayerMask interactableLayer; //for interacting with NPC
    

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
       if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

        if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }


        }
        animator.SetBool("isMoving", isMoving);
        //for interacting with NPC
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
    private bool IsWalkable (Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer | interactableLayer) != null)//for nbc
        {
            return false;
        }
        return true;
    }

    public object CaptureState()
    {
        float[] position = new float[] { transform.position.x, transform.position.y };
        return position;
    }

    public void RestoreState(object state) // use to restore data
    {
        var position = (float[])state;
        transform.position = new Vector3(position[0], position[1]);
    }
    //for interacting with NPC
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;


        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
    //
    public event Action Onupdate;
    public void CharaUpdated()
    {
        Onupdate?.Invoke();
    }


}
