using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public class Deck : ScriptableObject
{
	[SerializeField] private List<TaroCard> _cards = new();

	public List<TaroCard> Cards => _cards;
}
