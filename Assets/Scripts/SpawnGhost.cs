using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

    public GameObject ghost;
    
	// Use this for initialization
	void Start () {
		Instantiate(ghost, transform.position, Quaternion.identity);
	}
}
