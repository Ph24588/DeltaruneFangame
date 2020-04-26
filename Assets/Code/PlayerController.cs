using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private float inputX;
    private float inputY;
    private Rigidbody2D rb;
    private int xWall = 0;
    private int yWall = 0;

    //remove this later
    public GameObject proj;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() { 
        //replace this later
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(proj, new Vector3(0, 7, 0), Quaternion.identity);
        }

        inputX = Input.GetAxisRaw("Horizontal") * speed;
        inputY = Input.GetAxisRaw("Vertical") * speed;
        if ((xWall == 1 && inputX > 0) || (xWall == -1 && inputX < 0))
        {
            inputX = 0;
        }
        if ((yWall == 1 && inputY > 0) || (yWall == -1 && inputY < 0))
        {
            inputY = 0;
        }

        rb.velocity = new Vector3(inputX, inputY, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Projectile"))
        {
            Destroy(this.gameObject);
        }
        switch (collision.name)
        {
            case "RightWall":
                xWall = 1;
                break;
            case "LeftWall":
                xWall = -1;
                break;
            case "UpWall":
                yWall = 1;
                break;
            case "DownWall":
                yWall = -1;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "RightWall":
                xWall = 0;
                break;
            case "LeftWall":
                xWall = 0;
                break;
            case "UpWall":
                yWall = 0;
                break;
            case "DownWall":
                yWall = 0;
                break;
            default:
                break;
        }
    }
}
