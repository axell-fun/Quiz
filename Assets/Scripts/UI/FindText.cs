using UnityEngine;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class FindText : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private float _faidTime;
    
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _text.text = "Find " + _levelController.Symbol;

        if (_levelController.CurrentLevel != 0)
            _faidTime = 0;
            
        _text.DOFade(1, _faidTime);
    }
}
