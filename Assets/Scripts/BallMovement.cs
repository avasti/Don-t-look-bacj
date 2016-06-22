using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    public float speed;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));          
        if (player.transform.position.x - transform.position.x > 15)
        {
            speed = 10;
        }
        else
        {
            speed = 4;
        }
        if (player.transform.position.x < transform.position.x)
        {
            Assets.Scripts.ScoreManager.score = 0;
            SceneManager.LoadScene("Dead");
        }
        transform.localScale += new Vector3(0.0001f, 0.0001f, 0);        
    }    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "GameController")
            {
                Assets.Scripts.ScoreManager.score = 0;
                SceneManager.LoadScene("Dead");
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
