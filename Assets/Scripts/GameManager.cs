using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 boardSize;
    public Vector2 direction;
    /// <summary>
    /// Paskutinis elementas visuomet bus galva.
    /// </summary>
    public List<Vector2> body = new List<Vector2>() { };
    public Action<List<Vector2>> onMovementDone;
    public Action<Vector2> onFoodGenerated;
    private bool needsShrinking = true;
    public Vector2 foodPosition;
    public Action<List<Vector2>> onWallsGenerated;
    public List<Vector2> wallsPositions = new List<Vector2>();

	private void Start()
	{
        direction = new Vector2(1, 0);
        body.Add(new Vector2((int)(boardSize.x + 1) / 2, (int)(boardSize.y + 1)/ 2));
        GenerateWalls();
        GenerateFood();
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
            Vector2 newHeadPosition = body[body.Count - 1];
            newHeadPosition = newHeadPosition + direction;
            body.Add(newHeadPosition);

            needsShrinking = !FoodWasEaten(newHeadPosition);
            if (needsShrinking)
            {
                body.RemoveAt(0);
            }
            else
			{
                GenerateFood();
            }
            needsShrinking = true;

            List<Vector2> bodyList = new List<Vector2>();
            for (int i = 0; i < body.Count - 1; i++)
            {
                bodyList.Add(body[i]);
            }
            if (IsColliding(newHeadPosition, wallsPositions, bodyList))
            {
                //TODO:Do something.. 
			}

            if (onMovementDone != null)
            {
                onMovementDone(body);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Eat()
	{
        needsShrinking = false;
    }

    private void GenerateFood()
	{
        //Kazkaip geriau imanoma generuoti
        foodPosition.x = UnityEngine.Random.Range(0, (int)boardSize.x + 1);
        foodPosition.y = UnityEngine.Random.Range(0, (int)boardSize.y + 1);
        onFoodGenerated?.Invoke(foodPosition);
    }

    private bool FoodWasEaten(Vector2 coords)
	{
        if (coords == foodPosition)
		{
            return true;
		}
        return false;
	}

    private bool IsColliding(Vector2 checkedPosition, List<Vector2> walls, List<Vector2> body)
	{
        //galim tikrinti tik sienas
        if (walls.Contains(checkedPosition))
		{
            return true;
		}

        //galim tikrinti tik kuna
        if (body.Contains(checkedPosition))
		{
            return true;
		}

        return false;
	}

    private void GenerateWalls()
	{
        wallsPositions.Clear();
        for (var i = 0; i <= boardSize.x; i++)
		{
            for (var j = 0; j <= boardSize.y; j++)
			{
                if (i == 0 || i == boardSize.x || j == 0 || j == boardSize.y)
				{
                    wallsPositions.Add(new Vector2(i, j));
                }
			}
		}
        onWallsGenerated?.Invoke(wallsPositions);
	}
}


