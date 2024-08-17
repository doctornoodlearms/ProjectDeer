using System.Collections.Generic;
using Godot.Collections;

public static class Definitions {

	static void TestEffect() {

		GlobalVariables.Current.EnemyHealth -= 10;
	}
	static void NoEffect() {
		return;
	}
	static void DiscardTestEffect() {

		Logging.Print("Discarded");
	}

	public static List<Card> cookieList = new List<Card>() {
		new Card(
			cardName:"Test",
			cardText:"Test",
			cost:0,
			imagePath:"Test",
			effect:TestEffect,
			discardEffect:DiscardTestEffect
		)
	};
}