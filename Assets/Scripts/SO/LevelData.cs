using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public Data[] NewData;
}

[Serializable]
public struct Data
{
    public Sprite CellSprite;
    public string CellName;
}