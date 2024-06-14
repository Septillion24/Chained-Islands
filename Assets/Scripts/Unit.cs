using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ISelectable
{
    public HealthBar healthBar;

    public string unitName;
    public Island currentLocation;
    public int currentHealth;
    public int maxHealth;
    public int attack;
    public int movement;
    public int maxMovement;



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

    void Awake()
    {
        currentHealth = maxHealth;
        RefreshMovement();
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

    public void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar();
    }

    public void MoveTo(Island islandToGoTo)
    {
        currentLocation = islandToGoTo;
        transform.position = islandToGoTo.transform.position;
    }

    public void ReduceMovement(int count)
    {
        movement -= count;
    }
    public void RefreshMovement()
    {
        movement = maxMovement;
    }

}
