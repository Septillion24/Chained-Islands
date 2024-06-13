using UnityEngine;

public interface ISelectable
{
    public bool isSelected { get; set; }
    public void OnSelect();
    public void OnDeselect();
    public GameObject GetGameObject();
}