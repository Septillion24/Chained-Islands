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

    // public TextMeshProUGUI nameTag;

    // Start is called before the first frame update
    void OnValidate()
    {
        // nameTag = GetComponentInChildren<TextMeshProUGUI>(true);
        nameTag.text = unitName;
        trueNameTag.text = $"\"{trueName}\"";
    }

    void Start()
    {
        // nameTag = GetComponentInChildren<TextMeshProUGUI>(true);
        nameTag.text = unitName;
        trueNameTag.text = $"\"{trueName}\"";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Island islandToGoTo)
    {
        currentLocation = islandToGoTo;
        transform.position = islandToGoTo.transform.position;
    }

    public override void OnSelect()
    {
        base.OnSelect();
        print("Selected " + unitName + ", " + nameTag);
        nameTag.gameObject.SetActive(true);
        trueNameTag.gameObject.SetActive(true);
    }
    public override void OnDeselect()
    {
        base.OnDeselect();
        nameTag.gameObject.SetActive(false);
        trueNameTag.gameObject.SetActive(false);
    }

}
