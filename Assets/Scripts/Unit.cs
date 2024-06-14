using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable
{
    public string unitName;
    public Island currentLocation;
    public int currentHealth;
    public int maxHealth;
    public int attack;

    private bool _isSelected;
    public bool isSelected { get => _isSelected; set => _isSelected = value; }

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int DoAttackRoll()
    {
        return Random.Range(1, 7) + attack;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public virtual void OnSelect()
    {
        isSelected = true;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null && SelectableMaterials.selectedMaterial != null)
        {
            renderer.material = SelectableMaterials.selectedMaterial;
        }
    }

    public virtual void OnDeselect()
    {
        isSelected = false;
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.material = SelectableMaterials.defaultMaterial;
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
