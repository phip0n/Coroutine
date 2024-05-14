using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private float _increase;
    [SerializeField] private float _currentValue;

    private bool _isActive = false;
    private bool _testBool = true;
    private Coroutine _count;

    void Start()
    {
        _currentValue = 0;
    }

    void Update()
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
            StopCoroutine(_count);
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
        yield return wait;

        while (_isActive)
        {
            _currentValue += _increase;
            _text.text = _currentValue.ToString();
            yield return wait;
        }
    }
}
