using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float speed;   
    public float jumpSpeed = 500;
    public Image img;
    public Sprite empty;
    public Text text;
    public Sprite speedUp, speedDown;

    int lastX;
    Animator anim;
    float copyMaxSpeed;
    double time;
    bool isGround = false;
	// Use this for initialization
	void Start () {
        copyMaxSpeed = speed;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        lastX = (int)transform.position.x;
	}
	
	// Update is called once per frame
	void Update() {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.G))
        {
            copyMaxSpeed = 30;
            speed = 30;
        }
        lastX = (int)transform.position.x;
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));       
        
        if (Input.GetAxis("Jump") != 0 && isGround)
        {
            anim.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed * (speed / 4), 0), ForceMode.VelocityChange);
            isGround = false;
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        anim.SetBool("Sprint", speed == 6);
        anim.SetBool("Ski", speed == 5);
        if (time <= 0)
        {
            speed = copyMaxSpeed;
            time = 0;
            img.sprite = empty;
        }
        else
        {
            time -= Time.deltaTime;
        }		
        text.text = "Score: " + Assets.Scripts.ScoreManager.score;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndCube")
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }

        if (other.gameObject.tag == "Speed Up")
        {
            speed = 6;
            time = 2;
            img.sprite = speedUp;
            Destroy(other.gameObject);            
        }
        if (other.gameObject.tag == "Speed Down")
        {
            speed = 3f;
            img.sprite = speedDown;
            time = 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            Assets.Scripts.ScoreManager.score += 15;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Flag")
        {
            Assets.Scripts.ScoreManager.SaveScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        if (other.gameObject.tag == "Ski")
        {
            speed = 5;
            time = 30;
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform")
        {
            isGround = true;
        }
        if (other.gameObject.tag == "Platform")
        {
            float dot = Vector3.Dot(other.contacts[0].normal, Vector3.right);
            Debug.Log(dot);
            if (dot < 0)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * 2 * speed, transform.position.y + .2f * jumpSpeed, transform.position.z);
            }
        }
    }
}
