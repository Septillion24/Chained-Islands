using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    public Material defaultSpriteMaterial;
    public Material spriteSelectionMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Selectable.defaultMaterial = defaultSpriteMaterial;
        Selectable.selectedMaterial = spriteSelectionMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
