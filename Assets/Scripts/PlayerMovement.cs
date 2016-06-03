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
	public AudioClip[] sounds;
    public AudioSource source;

    Animator anim;
    float copyMaxSpeed;
    double time;
    bool isGround = false;
    bool jumping = false;

	// Use this for initialization
	void Start () {
        copyMaxSpeed = speed;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.G))
        {
            /*Assets.Scripts.ScoreManager.Score += 2000;
            Assets.Scripts.ScoreManager.SaveScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");*/
            speed = 7;
            copyMaxSpeed = 7;
        }
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));       
        
        if ((Input.GetAxis("Jump") != 0 || Input.touchCount > 0) && isGround && !jumping)
        {
            jumping = true;
            isGround = false;
            anim.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.VelocityChange);
            source.clip = sounds[1];
            source.Play();
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumping = false;
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
            source.clip = sounds[2];
            source.Play();
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
            source.clip = sounds[0];
            source.Play();
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
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Platform" || other.gameObject.tag == "Cotxe")
        {
            isGround = true;
        }
        if (other.gameObject.tag == "Platform")
        {
            float dot = Vector3.Dot(other.contacts[0].normal, Vector3.right);
            if (dot < 0)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * 2 * speed, transform.position.y + .2f * jumpSpeed, transform.position.z);
            }
        }
    }
}
