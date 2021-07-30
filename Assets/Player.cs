using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    [SerializeField] KeyCode space = KeyCode.Space;
    [SerializeField] KeyCode ups = KeyCode.UpArrow;
    [SerializeField] public Vector3 moveDirection;
    private GameObject player;
    [SerializeField] bool isCrashed;
    [SerializeField] float jumpVelocity = 4;
    void Start()
    {
        Debug.Log("I started");
        InvokeRepeating("tick", 1f, 1f);
        
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (Input.GetKeyDown(ups))
        {
            Debug.Log("jump");
           
            GetComponent<Rigidbody>().velocity += (Vector3.up * jumpVelocity);
        }
    }
    private void FixedUpdate()
    {
        //every tick increase x speed by 0.3

    }
    private void tick()
    {
        if(!isCrashed){
        moveDirection.x += 0.3f;
        GetComponent<Rigidbody>().AddForce(moveDirection);
        }
    }
    
    void jump()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(space) || Input.GetKeyDown(ups))
        {
            Debug.Log("jump");
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        isCrashed = true;
        collision.gameObject.GetComponent<Rigidbody>().MovePosition(Vector3.up);
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.LogError("You Died");
        moveDirection.x = 0f;
    }
}
