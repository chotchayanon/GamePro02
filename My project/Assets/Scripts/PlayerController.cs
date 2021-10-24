using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2f;
    public float rotSpeed = 20f;
    float newRotY = 0;
    float newX = 0;
    float newY = 0;
    float newZ = 0;
    // Update is called once per frame
    void Update()
    {
        newY = transform.position.y;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            newRotY = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            newRotY = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            {
                newX = transform.position.x + speed * Time.deltaTime;
                newRotY = 90;
            }
        if (Input.GetKey(KeyCode.LeftArrow))
            {
                newX = transform.position.x - speed * Time.deltaTime;
                newRotY = -90;
            }
            
            transform.position = new Vector3(newX, newY, newZ);
            transform.rotation = Quaternion.Lerp(
                                                    Quaternion.Euler(0, newRotY, 0),
                                                    transform.rotation,
                                                    Time.deltaTime * rotSpeed
                                                 );
        
    }
        private void OnCollisionEnter(Collision collision)
        {
            print(collision.gameObject.name);
            if (collision.gameObject.name == "Sphere")
            {
                transform.localScale = new Vector3(2, 2, 2);

            }
            if (collision.gameObject.name == "Cube")
            {
                transform.localScale = new Vector3(1, 1, 1);

            }

        }
    
}