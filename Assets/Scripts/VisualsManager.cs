using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsManager : MonoBehaviour
{
    public GameManager gameManager;
	public Transform character;

	private void Start()
	{
		gameManager.onMovementDone = KaiPajudejom;
	}

	public void KaiPajudejom()
	{
		character.position = gameManager.position;
	}
}


