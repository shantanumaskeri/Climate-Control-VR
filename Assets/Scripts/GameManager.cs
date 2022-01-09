using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Props & Timelines")]
    public GameObject[] props;
    public GameObject[] timelines;
   
    [Header ("Environments")]
    public GameObject factory;
    public GameObject nature;

    private int numberOfProps;

    // Start is called before the first frame update
    private void Start()
    {
        numberOfProps = props.Length;

        /*for (int i = 0; i < numberOfProps; i++)
        {
            MeshRenderer[] propChildrenRenderers = props[i].GetComponentsInChildren<MeshRenderer>();

            for (int j = 0; j < propChildrenRenderers.Length; j++)
            {
                Material[] materials = propChildrenRenderers[j].gameObject.GetComponent<MeshRenderer>().materials;

                for (int k = 0; k < materials.Length; k++)
                {
                    Debug.Log("name of material: " + materials[k].name);
                    materials[k].SetFloat("_Mode", 3);
                }
            }
        }*/
    }

    public void SwitchEnvironmentTo(string name)
    {
        if (name == "nature")
        {
            nature.SetActive(true);
            factory.SetActive(false);
        }

        if (name == "factory")
        {
            nature.SetActive(false);
            factory.SetActive(true);
        }
    }

    public void ParseThroughObjects(GameObject go, GameObject timelineAnim)
    {
        if (go.GetComponent<ObjectProperties>().isAtEnd)
        {
            go.GetComponent<ObjectProperties>().isSelected = !go.GetComponent<ObjectProperties>().isSelected;

            for (int i = 0; i < numberOfProps; i++)
            {
                props[i].GetComponent<ObjectProperties>().isSelected = false;
                props[i].GetComponent<ObjectProperties>().canRotate = false;
            }

            timelineAnim.SetActive(false);
            go.GetComponent<ObjectProperties>().canRotate = false;

            StopAllCoroutines();
        }

        if (go.GetComponent<ObjectProperties>().isAtStart)
        {
            for (int i = 0; i < numberOfProps; i++)
            {
                props[i].GetComponent<ObjectProperties>().isSelected = false;
                props[i].GetComponent<ObjectProperties>().canRotate = false;

                timelines[i].SetActive(false);
            }

            go.GetComponent<ObjectProperties>().isSelected = !go.GetComponent<ObjectProperties>().isSelected;

            StartCoroutine(ShowTimeline(go, timelineAnim));
        }
    }

    private IEnumerator ShowTimeline(GameObject go, GameObject timelineAnim)
    {
        yield return new WaitForSeconds(2.0f);

        timelineAnim.SetActive(true);
        go.GetComponent<ObjectProperties>().canRotate = true;
    }

}
