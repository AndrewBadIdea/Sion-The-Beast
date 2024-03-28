using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;

    public float MoveSpeed = 5f;


    Vector2 Move;



    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move.x = Input.GetAxisRaw("Horizontal");
        Move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        player.velocity = new Vector2(Move.x * MoveSpeed, Move.y * MoveSpeed);
    }
}
