using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour {

    public float speed = 10;
    public float startX = 31.26f;
    public float endX = -31.26f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= endX){
            Vector2 initialPos = new Vector2(startX, transform.position.y);
            transform.position = initialPos;
        }
	}
}
