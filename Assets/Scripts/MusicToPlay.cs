using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToPlay : MonoBehaviour
{
	public static MusicToPlay instance;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		


	}
}
