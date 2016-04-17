using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float speed;   
    public float maxSpeed = 5;
    public float jumpSpeed = 500;
    public Image img;
    public Sprite empty;

    float copyMaxSpeed;
    double time;
    bool isGround = false;
	// Use this for initialization
	void Start () {
        copyMaxSpeed = maxSpeed;
	}
	
	// Update is called once per frame
	void Update() {
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));
        if (Input.GetAxis("Jump") != 0 && isGround)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0));
            isGround = false;
        }
        if (time <= 0)
        {
            maxSpeed = copyMaxSpeed;
            time = 0;
            img.sprite = empty;
        }
        else
        {
            time -= Time.deltaTime;
        }
		speed += Time.deltaTime;
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

        if (other.gameObject.tag == "Speed Up")
        {
            maxSpeed = 6;
            time = 2;
            Destroy(other.gameObject);            
        }
        if (other.gameObject.tag == "Speed Down")
        {
            maxSpeed = 3.2f;
            time = 1.3;
            Destroy(other.gameObject);
        }
    }
}
