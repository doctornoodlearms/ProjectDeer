using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

public partial class DeckController : Node {

	[Signal] public delegate void PlayerDrawCardEventHandler(Card newCard);
	[Signal] public delegate void PlayerDiscardCardEventHandler(int cardHandIndex);

	int playerCardCount;
	public int PlayerCardCount;

	private List<Card> CurrentDeck;
	private List<Card> CurrentHand;

	public static DeckController Current;

	public List<Card> Shuffle(List<Card> cardList) {

		List<Card> newCardList = cardList;

		for (int i = 0; i < cardList.Count; i++) {

			int randIndex = GD.RandRange(0, cardList.Count);

			newCardList.Add(cardList[randIndex]);
			cardList.RemoveAt(randIndex);
		}

		return newCardList;
	}

	public void SetDeck(List<Card> newDeck) {

		CurrentDeck = newDeck;
	}


	public void DrawCard() {

		// var CurrentDeck = PlayerDecks[index];
		// CurrentHand[index].Add(CurrentDeck[0]);
		// CurrentDeck.Remove(CurrentDeck[0]);

		Card newCard = CurrentDeck[0];

		CurrentHand.Add(CurrentDeck[0]);
		CurrentDeck.RemoveAt(0);
		EmitSignal(SignalName.PlayerDrawCard, newCard);
	}
	public void QueueRemoveCard(int cardHandIndex) {

		Logging.Print("Discarding: " + cardHandIndex);

		EmitSignal(SignalName.PlayerDiscardCard, cardHandIndex);
	}
	public void RemoveCard(int cardHandIndex) {

		CurrentHand.RemoveAt(cardHandIndex);
	}

	public void ActivateCard(int cardHandIndex, bool discardAfterEffect = true) {

		CurrentHand[cardHandIndex].Activate();
		if (discardAfterEffect == true) QueueRemoveCard(cardHandIndex);
	}
	public void DiscardActivate(int cardHandIndex) {

		CurrentHand[cardHandIndex].Discard();
	}


	// public List<Card> ReturnPlayerCurrent(int index) {
	// 	return CurrentHand[index];
	// }

	public override void _EnterTree() {

		Current = this;
		CurrentHand = new List<Card>();
		CurrentDeck = Definitions.cookieList;
	}
}
