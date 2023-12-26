using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 0.3f;

    private RawImage _image;
    private float _imagePositionX;
    private float _imagePositionY = 0;
    private int _finalValue = 1;
    private int _initialValue = 0;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if (_imagePositionX > _finalValue)
            _imagePositionX = _initialValue;

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}