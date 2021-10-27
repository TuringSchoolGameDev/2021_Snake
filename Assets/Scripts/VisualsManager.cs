using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour
{
    public GameManager gameManager;
	public GameObject bodyPartPrefab;

	private void Start()
	{
		gameManager.onMovementDone = KaiPajudejom;
	}

	public void KaiPajudejom(Vector2 headPosition)
	{
		GameObject prefabInstance = Instantiate(bodyPartPrefab);
		prefabInstance.transform.position = headPosition;
	}
}


