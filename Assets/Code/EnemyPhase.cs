using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour {

    public GameObject player;
    public GameObject arena;

	// Use this for initialization
	void Start () {
        Instantiate(arena, new Vector3(0, 0, 1), Quaternion.identity);
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
