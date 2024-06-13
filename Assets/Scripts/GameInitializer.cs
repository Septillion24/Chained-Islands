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
        SelectableMaterials.defaultMaterial = defaultSpriteMaterial;
        SelectableMaterials.selectedMaterial = spriteSelectionMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
