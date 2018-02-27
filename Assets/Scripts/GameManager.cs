using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManagerInstance { get; private set; }

	private void Awake()
	{
		gameManagerInstance = this;
	}
}
