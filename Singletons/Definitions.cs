using System;
using System.Collections.Generic;
using System.ComponentModel;
using Godot.Collections;

public static class Definitions {


	// EFFECTS

	// Examples Effects
	static void TestEffect() {

		GlobalVariables.Current.EnemyHealth -= 10;
	}
	static void DiscardTestEffect() {

		Logging.Print("Discarded");
	}
	static void EnemyEffect() {

		GlobalVariables.Current.PlayerHealth -= 10;
	}

	// No Effect
	static void NoEffect() {
		return;
	}

	// Standard Effects
	static void StandardPlayerAttack() {

		GlobalVariables.Current.EnemyHealth -= 10;
	}
	static void StandardPlayerBlock() {

		BuffController.Current.AddPlayerBuff(blockBuff, 10);
	}

	// Cookie Effects

	// Cookie Buffs
	public static Buff cookieBuff = new Buff(

		newId: "cookie.basebuff",
		newName: "Crumb",
		newDescription: "Crumbs",
		newStacks: 1,
		newDecay: false
	);
	public static Buff blockBuff = new Buff(
		newId: "standard.block",
		newName: "Block",
		newDescription: "Prevents X damage",
		newStacks: 1,
		newDecay: true
	);

	static Card StandardAttack = new Card(
			cardName: "Damage",
			cardText: "Deal 10 damage to the enemy",
			cost: 1,
			imagePath: "Test",
			effect: StandardPlayerAttack,
			discardEffect: NoEffect
	);
	static Card StandardBlock = new Card(
			cardName: "Block",
			cardText: "Prevents X damage",
			cost: 1,
			imagePath: "Test",
			effect: StandardPlayerBlock,
			discardEffect: NoEffect
	);

	// Cookie List
	public static List<Card> cookieList = new List<Card>() {
		StandardAttack,
		StandardBlock
	};

	public static List<Action> enemyList = new List<Action>() {

		EnemyEffect
	};



	public static Enemy testEnemy = new Enemy(
		name: "Test Enemy",
		health: 100,
		actions: enemyList
	);
}