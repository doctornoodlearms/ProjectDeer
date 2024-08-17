using System;

/// <summary>
/// </summary>
public partial class Card : Resource {

	public int Cost { get; }
	public int MaxCost { get; }
	public string ImageResourcePath { get; }
	public string CardName { get; }
	public string CardText { get; }

	Action ActivateEffect { get; }
	Action DiscardEffect { get; }

	public Card(string cardName, string cardText, int cost, string imagePath, Action effect, Action discardEffect = null) {

		Cost = cost;
		MaxCost = cost;
		ImageResourcePath = imagePath;
		CardName = cardName;
		CardText = cardText;
		ActivateEffect = effect;
		DiscardEffect = discardEffect;
	}

	public void Activate() {

		ActivateEffect();
		GlobalVariables.Current.PlayerEnergy -= Cost;
	}
	public void Discard() {

		if (DiscardEffect == null) return;
		DiscardEffect();
	}
}