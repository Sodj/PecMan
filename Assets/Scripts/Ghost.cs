using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ghost : MonoBehaviour {

    public int damage = 1;
    public float speed = 5;
    public GameObject effect;
    public Shake shake;
    // Use static so that all instances get the same value
    public static int score = 0;
    public static Text scoreText;
    public static Text healthText;
    public GameObject explodeSound;
    
    void Start(){
        if(shake      == null) shake      = GameObject.FindGameObjectWithTag("screenshake").GetComponent<Shake>();
        if(scoreText  == null) scoreText  = GameObject.Find("Canvas/Score" ).GetComponent<Text>();
        if(healthText == null) healthText = GameObject.Find("Canvas/Health").GetComponent<Text>();
    }

    void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.CompareTag("Player")){
            shake.ShakeCamera();
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(explodeSound, transform.position, Quaternion.identity);
            Pacman pacman = other.GetComponent<Pacman>();
            pacman.health -= damage;
            healthText.text = "Health: " + pacman.health.ToString();
            Debug.Log("Health: " + pacman.health);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Finish")){
            scoreText.text = "Score: " + (++score).ToString();
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
}
