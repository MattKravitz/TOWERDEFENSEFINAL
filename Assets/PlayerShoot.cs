using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public Transform turret; //used to interact with the player-controlled tower
    public GameObject bullet; //used to generate projectiles from the bullet prefab

    private float turn; //used to control how fast it's rotating
    private float vertical;

    private static int m_health = 100;
    private float shot_speed = 0;

    private float delayTime = 0;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shot_speed = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space)) //press
        {
            if(Time.time > delayTime)
            {
                Instantiate(bullet, turret.position, turret.rotation);
                shot_speed = (Time.time - shot_speed) * 5f;
                if(shot_speed > 3)
                {
                    shot_speed = 3;
                }
                bullet.GetComponent<BulletBehavior>().setSpeed(shot_speed);
                delayTime = Time.time + 0.5f;
            }
        }
    }
    /// <summary>
    /// Takes the damage.
    /// </summary>
    /// <param name="enemyDealingDamage">The enemy dealing damage.</param>
    public void takeDamage(enemy enemyDealingDamage)
    { 
        int damageTaken = enemyDealingDamage.getDamage();
        int newHealth = m_health - damageTaken;

        setHealth(newHealth);
        Debug.Log("Health Set to " + getHealth());
    }
    /// <summary>
    /// Sets the health.
    /// </summary>
    /// <param name="newHealth">The new health.</param>
    public void setHealth(int newHealth)
    {
        m_health = newHealth;
    }

    /// <summary>
    /// Gets the health.
    /// </summary>
    /// <returns></returns>
    public static int getHealth()
    {
        return m_health;
    }
}
