﻿using UnityEngine;
using System.Collections;

enum EnemyType { Red = 1,Green = 2,Blue = 3};

public class Enemy : MonoBehaviour {
    // for testing purposes. Will not exist in final build.
    public bool isColliding;

	// Use this for initialization
	void Start () {

        // Get the renderer
        Renderer rend = GetComponent<Renderer>();

        isColliding = false;
        EnemyType type = GetRandomEnum();

        // if statements will check the type, and then color the material accordingly.
        if(type == EnemyType.Blue)
        {
            rend.material.SetColor("_Color", Color.blue);
        }
        else if(type == EnemyType.Green)
        {
            rend.material.SetColor("_Color", Color.green);
        }
        else if(type == EnemyType.Red)
        {
            rend.material.SetColor("_Color", Color.red);
        }
}
	
	// Update is called once per frame
	void Update () {
        // Very primitive, meant for testing.
        transform.Translate(Vector3.down * Time.deltaTime);
	}

    // When sphere collider triggers, check if the collided object is a player.
    // If so, delete current gameObject and subtract one health.
    void OnTriggerEnter(Collider other)
    {
        // check for the player tag. If it exists, set collision to true and then destroy existing gameobject
        if(other.tag == "Player")
        {
            
            isColliding = true;
            Destroy(gameObject);

        }
    }

    // Gets a random enum by using the values existing within the enum
    static EnemyType GetRandomEnum()
    {
        // create an array that holds the values of each EnemyType
        System.Array a = System.Enum.GetValues(typeof(EnemyType));
        // cycle through the array and then return a random enum type
        EnemyType newEnemy = (EnemyType)a.GetValue(Random.Range(0, a.Length));
        return newEnemy;
    }
}
