using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPad : MonoBehaviour
{
    Rigidbody rigid;

    Vector3 moveVec = Vector3.zero;
    Vector3 dir = Vector3.right;
    public float moveSpeed = 1f;
    private float count = 0;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        count += Time.deltaTime;

        if(count > 3f)
        {
            dir = dir * -1;
            count = 0f;
        }
    }


    private void FixedUpdate()
    {
        moveVec = dir * moveSpeed;
        rigid.velocity = moveVec;
    }

    public Vector3 GetVec()
    {
        return moveVec;
    }

}
