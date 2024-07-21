using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]

public class PoolView<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private ItemPool<T> _pool;
    [SerializeField] private string _title;
    private Text _view;

    private void OnEnable() => _pool.CountChanged += Show;

    private void OnDisable() => _pool.CountChanged -= Show;

    private void Start()
    {
        _view = GetComponent<Text>();
        _view.text = $"{_title}: 0";
    }

    private void Show(int countAll, int countActive) => _view.text = $"{_title}: {countActive} / {countAll}";
}