using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerRigidbody : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody rb;
    float newRotY = 0;
    public float rotSpeed = 20f;
    public GameObject prefabBullet;
    public Transform gunPosition;
    public float gunPower = 15f;
    public float gunCooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public int bulletCount = 0;

    public int coinCount = 0;
    public PlaygroundSceneManager manager;
    public AudioSource audioCoin;
    public AudioSource audioFire;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<PlaygroundSceneManager>();
        if(manager == null)
        {
            print("Manager not found!!");
        }

        if(PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        manager.SetTextCoin(coinCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      /*  if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(0, 0, speed,ForceMode.VelocityChange);
            newRotY = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(0, 0, -speed,ForceMode.VelocityChange);
            newRotY = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(speed, 0, 0,ForceMode.VelocityChange);
            newRotY = 90;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-speed, 0, 0,ForceMode.VelocityChange);
            newRotY = -90;
        }
        */
        float horizontal = Input.GetAxis("Horizontal") * speed; 
        float vertical = Input.GetAxis("Vertical") * speed;
        if (horizontal > 0)
        {
            newRotY = 90;
        }
        else if (horizontal < 0) 
        {
            newRotY = -90;
        }
        if(vertical > 0)
        {
            newRotY = 0;
        }
        else if (vertical < 0) 
        {
            newRotY = 180;
        }

        rb.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRotY, 0),
                                                    transform.rotation,
                                                    Time.deltaTime * rotSpeed);
    }
    private void Update()
    {
        gunCooldownCount +=  Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (bulletCount > 0) && (gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            GameObject bullet = Instantiate(prefabBullet, gunPosition.position, gunPosition.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 2f);

            bulletCount--;
            manager.SetTextBullet(bulletCount);
            audioFire.Play();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            //coinCount = coinCount + 1;
            coinCount++;
            manager.SetTextCoin(coinCount);
            audioCoin.Play();
            


        }
        if(other.gameObject.name == "Gun")
        {
            //print("Yea! I have a gun");
            Destroy(other.gameObject);
            hasGun = true;
            bulletCount += 10;
            manager.SetTextBullet(bulletCount);   
        }
    }
}
