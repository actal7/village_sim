using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public TileData[,] grid;

    void Awake()
    {
        InitializeGrid();
    }

    void InitializeGrid()
    {
        grid = new TileData[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                grid[x, y] = new TileData(TileType.Floor);
            }
        }
        Debug.Log($"Grid initialized ({width}x{height})");
    }
}