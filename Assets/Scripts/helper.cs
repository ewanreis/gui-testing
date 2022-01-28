using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper : MonoBehaviour
{
    public static void MoveEntity(float xVelocity, float yVelocity, Rigidbody2D entityRigid)
    {
        if (entityRigid.velocity.x > -10f && entityRigid.velocity.x < 10f)
            entityRigid.AddForce(new Vector2(xVelocity, 0), ForceMode2D.Force);
        if (entityRigid.velocity.y >= 0f && entityRigid.velocity.y < 0.05f)
            entityRigid.AddForce(new Vector2(0, yVelocity), ForceMode2D.Impulse);
    }
    public static float PlayerMovementRestraints(bool jumping, bool isIdle, bool left, bool right, char mode)
    {
        float velocity = 0;
        switch (mode)
        {
            case 'x':
                if (left == true && right == false)
                    velocity = -10f;
                if (right == true && left == false)
                    velocity = 10f;
                if (right == false && left == false && isIdle == true)
                    velocity = 0f;
                break;
            case 'y':
                velocity = (jumping == true) ? 5f : 0f;
                break;
        }
        return velocity;
    }
    public static bool PlayerBoolSwitcher(string mode, float x, float y)
    {
        bool check;
        check = mode switch
        { 
            "jump" => check = (y > 0) ? true : false, 
            "left" => check = (x < 0) ? true : false,
            "right" => check = (x > 0) ? true : false,
            "idle" => check = (x == 0 && y == 0) ? true : false,
            _ => false
        };
        return check;
    }
    public static void InstantiateFireBall(GameObject obj, GameObject target, float xpos, float ypos, float xvel, float yvel)
    {
        GameObject instance = Instantiate(obj, new Vector3(xpos, ypos, 0), Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        float step = 1 * Time.deltaTime; // calculate distance to move
        rb.velocity = Vector3.MoveTowards(obj.transform.position, target.transform.position, Time.deltaTime * 2);
        Vector2 moveDirection = (target.transform.position - obj.transform.position).normalized * 20;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(instance, 5f); // Destroy Bullet after 5 seconds
    } // Instantiate any projectile with a set Velocity
}
