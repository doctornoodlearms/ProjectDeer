using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class DeckController : Node
{
	private Godot.Collections.Dictionary<int, List<Card>> PlayerDecks;
	private Godot.Collections.Dictionary<int, List<Card>> CurrentHand;


    public void Shuffle(int deck)
    {
		var cards = PlayerDecks[deck];
		var rando= new Random();
		var shuffle=cards.OrderBy(_ => rando.Next()).ToList();
		PlayerDecks[deck] = shuffle;
    }



    public void DrawCard(int index) 
	{
		var CurrentDeck=PlayerDecks[index];
		CurrentHand[index].Add(CurrentDeck[0]);
		CurrentDeck.Remove(CurrentDeck[0]);

	}



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
