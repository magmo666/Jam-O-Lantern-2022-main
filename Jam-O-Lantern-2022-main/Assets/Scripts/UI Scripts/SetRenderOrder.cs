using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderOrder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        mr.sortingLayerID = SortingLayer.NameToID("Background");
        mr.sortingOrder = 1;

    }

}
