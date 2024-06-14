using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Unit
{

    [SerializeField] TextMeshProUGUI nameTag;
    [SerializeField] GameObject uiElements;

    void OnValidate()
    {
        nameTag.text = unitName;
    }


    // Start is called before the first frame update
    void Start()
    {

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

    public override void Die()
    {
        currentLocation.RemoveEnemy(this);
        base.Die();
    }

}
