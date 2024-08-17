using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class DeckController : Node
{
	private Godot.Collections.Dictionary<int, List<Card>> PlayerDecks;
	private Godot.Collections.Dictionary<int, List<Card>> CurrentHand;

	public static DeckController Current;

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


	public List<Card> ReturnPlayerCurrent(int index) 
	{
		return CurrentHand[index];
	}


    public override void _Ready()
    {
        Current=this;
    }


}
