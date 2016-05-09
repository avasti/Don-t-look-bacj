using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float speed;   
    public float maxSpeed = 5;
    public float jumpSpeed = 500;
    public Image img;
    public Sprite empty;
    public Text text;
    public Sprite speedUp, speedDown;

    Animator anim;
    float copyMaxSpeed;
    double time;
    bool isGround = false;
	// Use this for initialization
	void Start () {
        copyMaxSpeed = maxSpeed;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));
        if (Input.GetAxis("Jump") != 0 && isGround)
        {
            anim.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed, 0));
            isGround = false;
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        anim.SetBool("Sprint", maxSpeed == 6);
        anim.SetBool("Ski", maxSpeed == 5);
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
        text.text = "Score: " + Assets.Scripts.ScoreManager.Score;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndCube")
        {
            transform.position = new Vector3(0, transform.position.y, 0);
        }

        if (other.gameObject.tag == "Speed Up")
        {
            maxSpeed = 6;
            time += 2;
            img.sprite = speedUp;
            Destroy(other.gameObject);            
        }
        if (other.gameObject.tag == "Speed Down")
        {
            maxSpeed = 3f;
            img.sprite = speedDown;
            time += 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Coin")
        {
            Assets.Scripts.ScoreManager.Score += 15;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Flag")
        {
            Assets.Scripts.ScoreManager.SaveScore();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Dead");
        }
        if (other.gameObject.tag == "Ski")
        {
            maxSpeed = 5;
            time = 3;
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
