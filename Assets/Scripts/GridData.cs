using UnityEngine;

public enum TileType
{
    Floor,
    Wall,
    FoodResource,
    WoodResource,
    Grass
}

[System.Serializable]
public class TileData
{
    public TileType type = TileType.Floor;
    public bool isFlammable = false;
    public int resourceAmount = 0;


    public TileData(TileType t = TileType.Floor)
    {
        type = t;
    
        if (type == TileType.Grass) isFlammable = true;
        if (type == TileType.FoodResource) resourceAmount = 10;
        if (type == TileType.WoodResource) resourceAmount = 20;
    }
}