using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _sprite;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _particle;
    
    private string _cellName;
    private LevelController _levelController;

    private Action<bool> checkGameStatus;

    public void PlayAnimation()
    {
        _animator.SetBool("IsBounce", true);
    }

    public void SetCellData(Sprite newSprite, string cellName, LevelController levelController)
    {
        _sprite.sprite = newSprite;
        _cellName = cellName;
        _levelController = levelController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _levelController.CheckWin(_cellName, checkGameStatus =>
        {
            if (checkGameStatus)
            {
                _particle.SetActive(true);
                PlayAnimation();
            }
            else
            {
                _sprite.transform.DOLocalMoveX(-10, 0.2f).OnComplete(() =>
                {
                    _sprite.transform.DOLocalMoveX(10, 0.2f).OnComplete(() =>
                    {
                        _sprite.transform.DOLocalMoveX(0, 0.2f);
                    });
                });
            }
        });
    }
}
