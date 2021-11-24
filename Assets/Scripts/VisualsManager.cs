using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour
{
    public GameManager gameManager;
	public GameObject bodyPartPrefab;
	public GameObject wallPrefab;
	public List<GameObject> bodyVisuals = new List<GameObject>();
	public List<GameObject> wallsVisuals = new List<GameObject>();
	public GameObject foodVisuals;
	public Transform bodyParent;
	public Transform wallParent;
	private void Awake()
	{
		gameManager.onMovementDone = GenerateSnakeVisuals;
		gameManager.onFoodGenerated = OnFoodGenerated;
		gameManager.onWallsGenerated = OnWallsGenerated;
	}

	private void GenerateSnakeVisuals(List<Vector2> bodyPartsPositions)
	{
		//viska sunaikiti
		if (bodyVisuals.Count > 0)
		{
			for (int i = bodyVisuals.Count - 1; i >= 0; i--)
			{
				Destroy(bodyVisuals[i]);
			}
			bodyVisuals.Clear();
		}

		//1 - pradine salyga
		//2 -
		//3 - i++ = vienu padidina i reikse
		for (int i = 0; i < bodyPartsPositions.Count; i++)
		//foreach (Vector2 bodyPartsPosition in bodyPartsPositions)
		{
			GameObject prefabInstance = Instantiate(bodyPartPrefab, bodyParent);
			prefabInstance.name = string.Format("Body_{0}", i);
			prefabInstance.transform.position = bodyPartsPositions[i];
			bodyVisuals.Add(prefabInstance);
		}
	}

	private void OnFoodGenerated(Vector2 foodPosition)
	{
		foodVisuals.transform.position = foodPosition;
	}

	private void OnWallsGenerated(List<Vector2> wallsPositions)
	{
		//viska sunaikiti
		if (wallsVisuals.Count > 0)
		{
			for (int i = wallsVisuals.Count - 1; i >= 0; i--)
			{
				Destroy(wallsVisuals[i]);
			}
			wallsVisuals.Clear();
		}

		for (int i = 0; i < wallsPositions.Count; i++)
		{
			GameObject prefabInstance = Instantiate(wallPrefab, wallParent);
			prefabInstance.name = string.Format("Wall_{0}", i);
			prefabInstance.transform.position = wallsPositions[i];
			wallsVisuals.Add(prefabInstance);
		}
	}
}


