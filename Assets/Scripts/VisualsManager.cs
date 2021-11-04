using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour
{
    public GameManager gameManager;
	public GameObject bodyPartPrefab;
	public List<GameObject> bodyVisuals = new List<GameObject>();

	private void Start()
	{
		gameManager.onMovementDone = GenerateSnakeVisuals;
	}

	public void GenerateSnakeVisuals(List<Vector2> bodyPartsPositions)
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
			GameObject prefabInstance = Instantiate(bodyPartPrefab);
			prefabInstance.transform.position = bodyPartsPositions[i];
			bodyVisuals.Add(prefabInstance);
		}
	}
}


