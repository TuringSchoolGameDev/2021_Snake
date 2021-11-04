using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 direction;
    /// <summary>
    /// Paskutinis elementas visuomet bus galva.
    /// </summary>
    public List<Vector2> body = new List<Vector2>() { new Vector2(0, 0), };
    public Action<List<Vector2>> onMovementDone;
    private bool needsShrinking = true;

	private void Start()
	{
        StartCoroutine(Movement());
        StartCoroutine(StartEating());
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
            Vector2 newHeadPosition = body[body.Count - 1];
            newHeadPosition = newHeadPosition + direction;
            body.Add(newHeadPosition);

            if (needsShrinking)
            {
                body.RemoveAt(0);
            }
            needsShrinking = true;

            if (onMovementDone != null)
            {
                onMovementDone(body);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator StartEating()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Eat();
        }
    }

    public void Eat()
	{
        needsShrinking = false;
    }
}
