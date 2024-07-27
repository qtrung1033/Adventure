using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nguoichoi : MonoBehaviour
{
    public float tocdo;
    public float movemnentX;
    private Rigidbody2D rigid;
    public bool quaydau = true;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*Vector2 move = rigid.velocity;
        move.x = Input.GetAxis("Horizontal") * tocdo;
        rigid.velocity = move;*/

        movemnentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movemnentX, 0f, 0f) * tocdo * Time.deltaTime;

        if (quaydau == true && movemnentX == -1)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            quaydau = false;
        }
        if (quaydau == false && movemnentX == 1)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            quaydau = true;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = new Vector3(rigid.velocity.x,tocdo, 0f);
        }


    }
}
