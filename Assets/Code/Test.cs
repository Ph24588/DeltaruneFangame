using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
    InteractiveTextBox t1 = new InteractiveTextBox();
    t1.DisplayOneLine("first line here");
    t1 = new InteractiveTextBox();
    t1.DisplayOneLine("second line here");
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
