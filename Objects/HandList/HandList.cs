public partial class HandList : Node {

	PackedScene cardScene = GD.Load<PackedScene>("res://Objects/BaseCardScene/BaseCardScene.tscn");

	public override void _Ready() {

		DeckController.Current.PlayerDrawCard += AddCard;
		DeckController.Current.PlayerDiscardCard += RemoveCard;
	}

	public void AddCard(Card newCard) {

		BaseCardScene newCardScene = cardScene.Instantiate<BaseCardScene>();
		newCardScene.CardName = newCard.CardName;
		newCardScene.CardText = newCard.CardText;
		// Update Card Image
		newCardScene.Cost = newCard.Cost;
		AddChild(newCardScene);
	}

	public void RemoveCard(int cardHandIndex) {

		foreach (BaseCardScene i in GetChildren()) {

			if (i.CardHandIndex == cardHandIndex) i.Discard();
		}
	}
}