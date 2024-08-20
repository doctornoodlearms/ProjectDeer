using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	static void EnemyEffect() {

		GlobalVariables.Current.PlayerHealth -= 10;
	}

	public static List<Card> cookieList = new List<Card>() {

		new Card(
			cardName:"Test",
			cardText:"Test",
			cost:1,
			imagePath:"Test",
			effect:TestEffect,
			discardEffect:DiscardTestEffect
		)
	};
	public static List<Action> enemyList = new List<Action>() {

		EnemyEffect
	};

	public static Buff cookieBuff = new Buff(

		newId: "cookie.basebuff",
		newName: "Base Buff",
		newDescription: "Base Buff",
		newStacks: 1,
		newDecay: false
	);

	public static Enemy testEnemy = new Enemy(
		name: "Test Enemy",
		health: 100,
		actions: enemyList
	);
}