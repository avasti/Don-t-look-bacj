using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuffController : MonoBehaviour {
    public Image img;
    public Sprite speedUp, speedDown;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Speed Up")
        {
            img.sprite = speedUp;
        }
        if (other.gameObject.tag == "Speed Down")
        {
            img.sprite = speedDown;
        }
    }
}
