using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{

    [Header("Prop End Position")]
    public Vector3 endPosition;

    [Header("Prop Timeline")]
    public GameObject timelineAnim;

    [Header("Prop Animation Sequence")]
    public Sprite[] frames;

    private int index;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;

        index = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GetComponent<ObjectProperties>().canRotate)
        {
            if (!GetComponent<ObjectProperties>().isSelected)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, startPosition, Time.deltaTime * 5f);
                transform.localRotation = startRotation;

                GetComponent<ObjectProperties>().isAtEnd = false;
                GetComponent<ObjectProperties>().isAtStart = true;

                index = 0;
            }
            else
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, Time.deltaTime * 5f);

                GetComponent<ObjectProperties>().isAtEnd = true;
                GetComponent<ObjectProperties>().isAtStart = false;
            }
        }
        else
        {
            index++;
            if (index < frames.Length)
            {
                index = index % frames.Length;

                timelineAnim.GetComponent<SpriteRenderer>().sprite = frames[index];
            }

            if (GetComponent<ObjectProperties>().id < 3)
            {
                transform.Rotate(0.0f, 0.0f, 120.0f * Time.deltaTime);
            }
            else
            {
                transform.Rotate(0.0f, 120.0f * Time.deltaTime, 0.0f);
            }
        }
    }

}
