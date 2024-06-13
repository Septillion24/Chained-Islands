using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public static Material selectedMaterial;
    public static Material defaultMaterial;
    public bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSelect()
    {
        isSelected = true;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null && selectedMaterial != null)
        {
            renderer.material = selectedMaterial;
        }
    }
    public void OnDeselect()
    {
        isSelected = false;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.material = defaultMaterial;
        }
    }
    
}
