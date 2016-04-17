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
        transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
    }    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name != "Terra")
        {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
