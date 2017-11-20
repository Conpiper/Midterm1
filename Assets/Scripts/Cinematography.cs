﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematography : MonoBehaviour {

    private GameObject Player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
    //We are going to use a LateUpdate.
    //example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
	void LateUpdate () 
    {
        float x = Mathf.Clamp(Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
	}
}
