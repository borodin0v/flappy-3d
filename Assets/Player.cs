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
    [SerializeField] public float LRVelocity = 2;
    void Start()
    {
        Debug.Log("I started");
        
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (Input.GetKeyDown(ups))
        {
            Debug.Log("");
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            Debug.Log("Left");
            GetComponent<Rigidbody>().velocity += (Vector3.forward * LRVelocity );
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("Right");
            GetComponent<Rigidbody>().velocity += (Vector3.back * LRVelocity );
        }
    }
    private void FixedUpdate()
    {
        //every tick increase x speed by 0.3
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("jump");
            GetComponent<Rigidbody>().velocity += (Vector3.up * jumpVelocity);
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
