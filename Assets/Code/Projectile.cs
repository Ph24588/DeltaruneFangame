using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    public float life_time;
    private GameObject player;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (player.transform.position - this.gameObject.transform.position).normalized * speed;
        Destroy(this.gameObject, life_time);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
