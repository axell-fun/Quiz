using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject _loadPanel;
    [SerializeField] private TMP_Text _textLoad;
    
    public void StartLoad()
    {
        _loadPanel.SetActive(true);
        _textLoad.DOFade(1, 2);
        _loadPanel.GetComponent<Image>().DOFade(1, 2).OnComplete(() =>
        {
            StartCoroutine(LoadGame());
        });
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
