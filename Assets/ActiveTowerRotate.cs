using UnityEngine;
using System.Collections;

public class ActiveTowerRotate : MonoBehaviour {

    public Transform body; //used to interact with the player-controlled tower
    public Transform bullet; //used to generate projectiles from the bullet prefab
    private float turn; //used to control how fast it's rotating
    private static int m_health = 100;
    private float shot_speed;
    /// <summary>
    /// Rotates the tower and shoots projectiles based on user input
    /// </summary>
    void Update () {
        /*
        //if the user presses the w key, create a bullet with the same rotation as the tower
        if (Input.GetKeyDown(KeyCode.Space)) //press
        {
            shot_speed = 1;
        }
        else if (Input.GetKey(KeyCode.Space)) //hold
        {
            if(shot_speed < 24)
            {
                shot_speed+=1;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) //release
        {
            Instantiate(bullet, body.position + Vector3.up, body.rotation);
            bullet.GetComponent<BulletBehavior>().setSpeed(shot_speed);
        }

        //if the d key is pressed, rotate right
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A))) {

            turn = 5;
        }
        //if the a key is pressed, rotate left
        else if(Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D))) {

            turn = -5;
        }
        //otherwise, don't rotate
        else
        {
            turn = 0;
        }
        //rotate by the turn factor
        body.Rotate(0, turn, 0);
        */

    }
    public void takeDamage(enemy enemyDealingDamage)
    {

        int damageTaken = enemyDealingDamage.getDamage();
        int newHealth = m_health - damageTaken;

        setHealth(newHealth);
        Debug.Log("Health Set to");
        Debug.Log(getHealth());
    }
    public static void setHealth(int newHealth)
    {
        m_health = newHealth;
    }

    public static int getHealth()
    {
        return m_health;
    }
}
