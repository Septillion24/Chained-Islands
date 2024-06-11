using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Sprite islandSprite;
    public Island[] adjacentIslands;
    public int islandID;
    public int islandType;

    // Start is called before the first frame update
    void Start()
    {

    }


    void OnValidate()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = islandSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
