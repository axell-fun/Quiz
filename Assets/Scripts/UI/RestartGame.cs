using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image[] _images;

    private void ActivePanel()
    {
        _panel.SetActive(true);

        foreach (var image in _images)
            image.DOFade(1, 2);
        }

    private void OnEnable()
    {
        _levelController.GameFinished += ActivePanel;
    }

    private void OnDisable()
    {
        _levelController.GameFinished -= ActivePanel;
    }
}
