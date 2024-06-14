using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;


public class CohortUnit : Unit
{

    public string trueName;
    [SerializeField] TextMeshProUGUI nameTag;
    [SerializeField] TextMeshProUGUI trueNameTag;

    [SerializeField] GameObject uiElements;

    // public TextMeshProUGUI nameTag;

    // Start is called before the first frame update
    void OnValidate()
    {
        // nameTag = GetComponentInChildren<TextMeshProUGUI>(true);
        nameTag.text = unitName;
        trueNameTag.text = $"\"{trueName}\"";
    }

    void Awake()
    {
        // nameTag = GetComponentInChildren<TextMeshProUGUI>(true);
        nameTag.text = unitName;
        trueNameTag.text = $"\"{trueName}\"";
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public override void OnSelect()
    {
        base.OnSelect();
        uiElements.SetActive(true);
    }
    public override void OnDeselect()
    {
        base.OnDeselect();
        uiElements.SetActive(false);
    }

}
