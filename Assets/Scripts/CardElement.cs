using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardElement : MonoBehaviour, IBeginDragHandler, IDragHandler
{
	[SerializeField] private float _threshold;
	[SerializeField] private Image _spriteRenderer;
	[SerializeField] private Image _imageBg;
	private Vector2 _initialPos = Vector2.zero;

	private bool _isOpened;

	public Action<CardElement> Opened;

	public int Points { get; set; }
	public bool IsRotated { get; private set; }

	public Sprite Picture
	{
		set
		{
			_spriteRenderer.sprite = value;
			if (Random.Range(0, 2) == 1)
			{
				Rotate();
			}
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		_initialPos = eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (_isOpened)
		{
			return;
		}

		if (_initialPos.y - eventData.position.y > _threshold)
		{
			Rotate();
			Open();
		}
		else if (eventData.position.y - _initialPos.y > _threshold)
		{
			Open();
		}
	}

	private void Rotate()
	{
		IsRotated = !IsRotated;
		var tmp = _spriteRenderer.transform.localScale;
		tmp.y *= -1;
		_spriteRenderer.transform.localScale = tmp;
	}

	private void Open()
	{
		_isOpened = true;
		_imageBg.enabled = false;
		_spriteRenderer.gameObject.SetActive(true);

		Opened.Invoke(this);
	}
}
