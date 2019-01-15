using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn pawn;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void inputHandler()
    {
        pawn.move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
