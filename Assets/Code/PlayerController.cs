using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w")) {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("down") || Input.GetKey("s")) {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("right") || Input.GetKey("d")) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("left") || Input.GetKey("a")) {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
}
