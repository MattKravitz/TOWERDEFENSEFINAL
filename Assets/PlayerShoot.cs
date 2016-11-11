﻿using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public Transform turret; //used to interact with the player-controlled tower
    public Transform bullet; //used to generate projectiles from the bullet prefab
    private float turn; //used to control how fast it's rotating
    private float vertical;

    private static int m_health = 100;
    private float shot_speed;

    /// <summary>
    /// Rotates the tower and shoots projectiles based on user input
    /// </summary>
    void Update()
    {
        //if the d key is pressed, rotate right
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A)))
        {
            turn = 5;
        }
        //if the a key is pressed, rotate left
        else if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D)))
        {
            turn = -5;
        }
        else if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.W)))
        {
            vertical = -5;
        }
        else if (Input.GetKey(KeyCode.W) && !(Input.GetKey(KeyCode.S)))
        {
            vertical = 5;
        }
        //otherwise, don't rotate
        else
        {
            turn = 0;
            vertical = 0;
        }
        //rotate by the turn factor
        turret.RotateAround(turret.position,Vector3.up, turn);
        turret.Rotate(new Vector3(0, 0, vertical));

        if(turret.eulerAngles.z > 90 && turret.eulerAngles.z < 120)
        {
            turret.Rotate(new Vector3(0, 0, 90 - turret.eulerAngles.z));
        }
        else if(turret.eulerAngles.z < 300 && turret.eulerAngles.z > 120)
        {
            turret.Rotate(new Vector3(0, 0, 300 - turret.eulerAngles.z));
        }

        //if the user presses the space key, create a bullet with the same rotation as the tower
        if (Input.GetKeyDown(KeyCode.Space)) //press
        {
            Instantiate(bullet, turret.position, turret.rotation);
        }
        Debug.Log(turret.eulerAngles.z);
    }
    public void takeDamage(enemy enemyDealingDamage)
    {

        int damageTaken = enemyDealingDamage.getDamage();
        int newHealth = m_health - damageTaken;

        setHealth(newHealth);
        Debug.Log("Health Set to");
        Debug.Log(getHealth());
    }
    public void setHealth(int newHealth)
    {
        m_health = newHealth;
    }

    public static int getHealth()
    {
        return m_health;
    }
}
