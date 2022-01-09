using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelCreation _levelCreation;
    [SerializeField] private LevelData[] _levels;
    [SerializeField] private float _timeBeforeLevelChange;
    
    private int _currentLevel;
    private string _symbol;

    public string Symbol => _symbol;
    public int CurrentLevel => _currentLevel;

    public Action GameFinished;
    
    private void Awake()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevelValue");
        
        for (int i = 0; i < _levels[PlayerPrefs.GetInt("CurrentLevelValue")].NewData.Length; i++)
        {
            _levelCreation.SetLevelData(
                _levels[PlayerPrefs.GetInt("CurrentLevelValue")].NewData[i].CellSprite,
                _levels[PlayerPrefs.GetInt("CurrentLevelValue")].NewData[i].CellName
                );
        }

        int indexSymbol = Random.Range(0, _levels[PlayerPrefs.GetInt("CurrentLevelValue")].NewData.Length);
        _symbol = _levels[PlayerPrefs.GetInt("CurrentLevelValue")].NewData[indexSymbol].CellName;
    }

    private IEnumerator LoadNewLevel()
    {
        yield return new WaitForSeconds(_timeBeforeLevelChange);
        SceneManager.LoadScene(0);
    }
    
    public void EndLevel()
    {
        _currentLevel++;

        if (_currentLevel >= _levels.Length)
        {
            _currentLevel = 0;
            GameFinished?.Invoke();
            PlayerPrefs.SetInt("CurrentLevelValue", _currentLevel);
            return;
        }

        PlayerPrefs.SetInt("CurrentLevelValue", _currentLevel);

        StartCoroutine(LoadNewLevel());
    }

    public void CheckWin(string cellName, Action<bool> gameStatus)
    {
        if (_symbol == cellName)
        {
            EndLevel();
            gameStatus?.Invoke(true);
        }
        else
        {
            gameStatus?.Invoke(false);
        }
    }
}
