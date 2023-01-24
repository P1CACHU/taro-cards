using System;
using UnityEngine;

[Serializable]
public class TaroCard
{
	[SerializeField] private int _points;
	[SerializeField] private Sprite _picture;

	public int Points => _points;
	public Sprite Picture => _picture;
}
