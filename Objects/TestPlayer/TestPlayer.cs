using System;
using System.Collections.Generic;

public partial class TestPlayer : BaseCharacter {
	static int PlayerIndex = 0;

	DeckController deckController;

	List<Card> CurrentHand=new List<Card>();


	public override void _Ready() {

		GetNode<GlobalVariables>("/root/GlobalVariables").PlayerHealth_Updated += (int value) => Health = value;
		GetNode<GlobalVariables>("/root/GlobalVariables").PlayerMaxHealth_Updated += (int value) => MaxHealth = value;
		deckController = DeckController.Current;
		base._Ready();
	}

    public override void _Process(double delta)
    {
        CurrentHand=deckController.ReturnPlayerCurrent(PlayerIndex);
    }


}