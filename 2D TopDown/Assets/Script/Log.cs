using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Rigidbody2D myRigidbody;
    public Animator anim;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private void Start()
    {
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim.SetBool("wakeup", true);
    }
    private void FixedUpdate()
    {
        CheckDistance();
    }
    public virtual void CheckDistance()
    {
        if(Vector3.Distance(target.position,
            transform.position)<= chaseRadius
            && Vector3.Distance(target.position,
            transform.position)>attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                || currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position,
                    target.position,
                    moveSpeed * Time.deltaTime);
                ChageAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeup",true);
            }
        }
        else if(Vector3.Distance(target.position,
            transform.position) > chaseRadius)
        {
            anim.SetBool("wakeup", false);
        }
    }
    void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }
    public void ChageAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x<0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y<0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
    void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
