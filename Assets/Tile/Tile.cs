using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;

    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    Pathfinder pathfinder;

    public bool IsPlaceable { get { return isPlaceable; } }

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }   
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessfull;
            isSuccessfull = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isSuccessfull)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyRecievers();
            }
        }

    }
}
