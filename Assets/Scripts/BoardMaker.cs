using TMPro;
using UnityEngine;

public class BoardMaker : MonoBehaviour
{
	[SerializeField] private CardElement _element;
	[SerializeField] private Transform _parent;
	[SerializeField] private TMP_Text _scoreText;

	[SerializeField] private Deck _deck;

	private int _score;

	private void Start()
	{
		_scoreText.SetText(_score.ToString());

		var cards = _deck.Cards;
		cards.Shuffle();

		for (var i = 0; i < cards.Count; i++)
		{
			var element = Instantiate(_element, _parent);
			element.Points = cards[i].Points;
			element.Picture = cards[i].Picture;
			element.Opened += OnOpened;
		}

		_element.gameObject.SetActive(false);
	}

	private void OnOpened(CardElement card)
	{
		if (card.Points == 0)
		{
			_scoreText.SetText("Game Over");
			return;
		}

		if (card.IsRotated)
		{
			_score -= card.Points;
		}
		else
		{
			_score += card.Points;
		}

		_scoreText.SetText(_score.ToString());
	}
}
