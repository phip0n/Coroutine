using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private float _addedValue;
    [SerializeField] private float _currentValue;

    private bool _isActive = false;
    private Coroutine _count;

    private void Start()
    {
        _currentValue = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SwitchCounter();
        }
    }

    private void SwitchCounter()
    {
        if (_isActive)
        {
            _isActive = false;

            if (_count != null)
            {
                StopCoroutine(_count);
            }
        }
        else
        {
            _isActive = true;
            _count = StartCoroutine(Count());
        }
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isActive)
        {
            yield return wait;
            _currentValue += _addedValue;
            _text.text = _currentValue.ToString();
        }
    }
}
