using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    CharacterController cc;
    [SerializeField]
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {


    }

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementInput.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.y = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }

        Move(movementInput);
    }

    void Move(Vector2 direction)
    {
        cc.SimpleMove(direction.normalized * speed);
    }
}
