using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    float speed = 5.0f;
    Vector3 velocity;
    float zoomVelocity;
    float zoom = 5.0f;
    List<ISelectable> selectedObjects = new List<ISelectable>();

    public float zoomSpeed = 5.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 20.0f;
    public CohortManager cohortManager;
    public TurnManager turnManager;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left * speed * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up * speed * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right * speed * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down * speed * 5f * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            zoomVelocity -= zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoomVelocity += zoomSpeed * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                ISelectable selectable = hit.collider.gameObject.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    Select(selectable);
                }
            }
            else
            {
                DeselectAll();
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                Island island = hit.collider.gameObject.GetComponent<Island>();
                CohortUnit clickedUnit = hit.collider.gameObject.GetComponent<CohortUnit>();
                if (island != null)
                {
                    moveAllSelected(island);
                }
                else if (clickedUnit != null)
                {
                    island = clickedUnit.currentLocation;
                    moveAllSelected(island);
                }
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            turnManager.NextTurn();
        }

        transform.position += velocity * Time.deltaTime;
        zoom = Mathf.Clamp(zoom + zoomVelocity, minZoom, maxZoom);
        Camera.main.orthographicSize = zoom;

        velocity = Vector3.ClampMagnitude(velocity, speed);
        velocity *= Mathf.Pow(0.05f, Time.deltaTime);
        zoomVelocity *= Mathf.Pow(0.02f, Time.deltaTime);
    }

    private bool moveAllSelected(Island location)
    {
        bool success = true;
        foreach (ISelectable selectable in selectedObjects)
        {

            CohortUnit unit = selectable.GetGameObject().GetComponent<CohortUnit>();
            if (unit == null) continue;

            if (!cohortManager.TryMoveUnit(unit, location))
            {
                success = false;
            }

        }
        return success;
    }


    private void Select(ISelectable selected)
    {
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            foreach (ISelectable selectable in selectedObjects)
            {
                selectable.OnDeselect();
            }
            selectedObjects.Clear();
        }
        selected.OnSelect();
        selectedObjects.Add(selected);
    }
    private void DeselectAll()
    {
        foreach (ISelectable selectable in selectedObjects)
        {
            selectable.OnDeselect();
        }
        selectedObjects.Clear();
    }

}
