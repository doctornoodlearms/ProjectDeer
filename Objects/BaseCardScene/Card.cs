using System;

/// <summary>
/// </summary>
public class Card {

	int cost;
	int maxCost;
	string imageResourcePath;
	string cardName;
	string cardText;

	Action activateEffect;

	public Card(string newName, int newCost, string newImagePath, string newText, Action newEffect) {

		cost = newCost;
		maxCost = newCost;
		imageResourcePath = newImagePath;
		cardName = newName;
		cardText = newText;
		activateEffect = newEffect;
	}

	public void Activate() {

		activateEffect();
	}
}