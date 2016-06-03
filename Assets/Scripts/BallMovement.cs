using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    public float speed;
    public GameObject player;
    public GameObject sphere;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));          
        if (player.transform.position.x - transform.position.x > 10)
        {
            speed = 10;
        }
        else
        {
            speed = 4;
        }
        transform.localScale += new Vector3(0.0001f, 0.0001f, 0);
        sphere.transform.eulerAngles += new Vector3(0, 0, -1);
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
