using Godot;
using System;

public partial class EndTurnButton : Button {

	public override void _Pressed() {

		EnemyController.Current.PerformEnemyAction();
	}

}
