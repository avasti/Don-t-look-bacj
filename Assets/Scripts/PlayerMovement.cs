using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    float copyMaxSpeed;
    public float maxSpeed = 5;
    public float jumpSpeed = 500;
    double time;
    bool isGround = false;
	// Use this for initialization
	void Start () {
        copyMaxSpeed = maxSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        transform.Translate(new Vector3(0.1f * speed, 0, 0));
        if (Input.GetAxis("Jump") != 0 && isGround)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0));
            isGround = false;
        }
        if (time <= 0)
        {
            maxSpeed = copyMaxSpeed;
            time = 0;
        }
        else
        {
            time -= Time.deltaTime;
        }
        speed += 0.01f;
        speed = Mathf.Min(speed, maxSpeed);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Terra")
        {
            isGround = true;
        }
        if (other.gameObject.name == "EndCube")
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }

        if (other.gameObject.name == "SpeedUp")
        {
            maxSpeed = 6;
            time = 2;
        }
        if (other.gameObject.name == "SpeedDown")
        {
            maxSpeed = 3.2f;
            time = 1.3;
        }
    }
}
