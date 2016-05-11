using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DieText : MonoBehaviour {
    static string[] textos = { "You die...", "The ball catches you", "A player has been slain", "You should jump...", "Ball rekts you...", "Ha! You loose!", "Haters are gonna hate" };
    void Awake()
    {
        System.Random rand = new System.Random();
        GetComponent<Text>().text = textos[rand.Next(textos.Length)];  
    }
}
