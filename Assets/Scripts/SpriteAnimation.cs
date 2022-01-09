using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour
{
	
	#region Public variables

	public Sprite[] frames;
	public int framesPerSecond = 10;

	#endregion

    #region Monobehaviours

    // Update is called once per frame
    private void Update()
	{
		FindObjectOfType<ObjectProperties>().index = (int)(Time.time * framesPerSecond);
		//Debug.Log(gameObject.name + " : " + FindObjectOfType<ObjectProperties>().index);
		if (FindObjectOfType<ObjectProperties>().index <= frames.Length)
		{
			FindObjectOfType<ObjectProperties>().index = FindObjectOfType<ObjectProperties>().index % frames.Length;
			
			GetComponent<SpriteRenderer>().sprite = frames[FindObjectOfType<ObjectProperties>().index];
		}
	}

	#endregion

}
