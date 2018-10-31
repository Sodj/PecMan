using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacman : MonoBehaviour {

    public int step = 3;
    public int health = 3;
    public float speed = 20;
    private Vector2 targetPos = new Vector2(0, 0);
    public GameObject effect;
    public GameObject gameOver;
    public GameObject moveSound;
    public GameObject bgMusic;
	
	// Update is called once per frame
	void Update () {
        if(health <= 0){
            Destroy(gameObject);
            gameOver.SetActive(true); // show gameover overlay
            bgMusic.SetActive(false); // stop background music
            health = 3;
        }

		if(Input.GetKeyDown(KeyCode.UpArrow) && targetPos.y < step){
            // Trigger visual effect
            Instantiate(effect, transform.position, Quaternion.identity);
            // Trigger sound effect
            Instantiate(moveSound, transform.position, Quaternion.identity);
            // Set new taget position
            targetPos = new Vector2(targetPos.x, targetPos.y + step);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && targetPos.y > -step){
            // Trigger visual effect
            Instantiate(effect, transform.position, Quaternion.identity);
            // Trigger sound effect
            Instantiate(moveSound, transform.position, Quaternion.identity);
            // Set new taget position
            targetPos = new Vector2(targetPos.x, targetPos.y - step);
        }
        // Move to target position (animated)
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
	}
}
