using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{

    [Header("Prop ID")]
    public int id;

    [HideInInspector]
    public bool isSelected;
    [HideInInspector]
    public bool isAtStart;
    [HideInInspector]
    public bool isAtEnd;
    [HideInInspector]
    public int index;
    [HideInInspector]
    public bool canRotate;

    // Start is called before the first frame update
    private void Start()
    {
        isSelected = false;
        isAtStart = true;
        isAtEnd = false;
        canRotate = false;
    }

}
