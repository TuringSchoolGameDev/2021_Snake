using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 direction;
    public Vector2 position;
    public Action onMovementDone;

	private void Start()
	{
        StartCoroutine(Movement());
    }

	void Update()
    {
        //switch
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = new Vector2(0, 1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = new Vector2(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = new Vector2(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = new Vector2(1, 0);
        }
    }

    IEnumerator Movement()
	{
        while (true)
		{
            //naujas vektorius = X + Y = (X1+X2 , Y1+Y2)
            position = position + direction;
            onMovementDone();

            //yield return null;//skip viena kadra
            yield return new WaitForSeconds(1);

        }
    }
}
