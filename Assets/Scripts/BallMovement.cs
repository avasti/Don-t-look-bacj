using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    public float speed, maxSpeed;
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        transform.Translate(new Vector3(Time.deltaTime * 2 * speed, 0, 0));       
        speed += Time.deltaTime;
        speed = Mathf.Min(speed, maxSpeed);
        if (player.transform.position.x < transform.position.x)
        {
            Destroy(player);
        }
        transform.localScale += new Vector3(0.0001f, 0.0001f, 0);
    }    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "GameController")
            {
                Assets.Scripts.ScoreManager.Score = 0;
                SceneManager.LoadScene("Dead");
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
