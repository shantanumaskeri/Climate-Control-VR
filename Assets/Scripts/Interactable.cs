using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [Header("Prop Timeline")]
    public GameObject timelineAnim;

    public void Pressed()
    {
        /*MeshRenderer renderer = GetComponent<MeshRenderer>();
        bool flip = !renderer.enabled;

        renderer.enabled = flip;*/

        switch (GetComponent<ObjectProperties>().id)
        {
            case 1:
            case 2:
            case 3:
                FindObjectOfType<GameManager>().SwitchEnvironmentTo("nature");
                break;

            case 4:
            case 5:
            case 6:
                FindObjectOfType<GameManager>().SwitchEnvironmentTo("factory");
                break;
        }

        FindObjectOfType<GameManager>().ParseThroughObjects(gameObject, timelineAnim);
    }

}
