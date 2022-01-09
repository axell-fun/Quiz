using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCreation : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Transform _levelPanel;

    private List<Sprite> _sprites = new List<Sprite>();
    private List<string> _cellNames = new List<string>();

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < _sprites.Count; i++)
        {
            GameObject newCell = Instantiate(_cellPrefab, _levelPanel.position, Quaternion.identity, _levelPanel);

            Cell cell = newCell.GetComponent<Cell>();
            
            cell.SetCellData(_sprites[i], _cellNames[i], _levelController);

            if (_levelController.CurrentLevel == 0)
                cell.PlayAnimation();
        }
    }

    public void SetLevelData(Sprite sprites, string cellName)
    {
        _sprites.Add(sprites);
        _cellNames.Add(cellName);
    }
}
