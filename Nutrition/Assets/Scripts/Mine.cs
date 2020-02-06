﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mine : MonoBehaviour
{

    public int mineHealth;
    public GameObject food;
    Rigidbody mine;

    [SerializeField]
    private string tag;

    // Use this to get Nav Mesh Agent of the enemy
    void Start()
    {
        mine = GetComponent<Rigidbody>();

        if (mineHealth == 0)
        {
            mineHealth = 3;
        }

    }
    // The amount of damage that certain weapons will deal
    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Weapon")
        {
            mineHealth = mineHealth - 1;
            Debug.Log("Mine has been hited");
        }

        if (otherObj.gameObject.tag == "Rage Sword")
        {
            mineHealth = mineHealth - 1;
            Debug.Log("Mine has been hited");
        }


        if (otherObj.gameObject.tag == "Fireball")
        {
            mineHealth = mineHealth - 1;
            Destroy(otherObj.gameObject);
            Debug.Log("Mine has been hited");
        }

        if (otherObj.gameObject.tag == "Iceball")
        {
            mineHealth = mineHealth - 1;
            Destroy(otherObj.gameObject);
            Debug.Log("Mine has been hited");
        }

        if (mineHealth <= 0)
        {
            Destroy(gameObject);
            GameObject drop;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            drop = Instantiate(food, transform.position, food.transform.rotation);
            drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            drop.tag = tag;
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
            this.transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 2);
            Debug.Log("Mine has been destroyed");
        }
    }
}
