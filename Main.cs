using System.ComponentModel;

public partial class Main : Node {

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		GlobalVariables globalVar = GetNode<GlobalVariables>("/root/GlobalVariables");


		// UI Update Example
		// Every 2 seconds updates player health in GlobalVariables Node
		Timer timer = new Timer();
		timer.WaitTime = 2.0f;
		timer.Autostart = true;
		timer.OneShot = false;
		timer.Timeout += () => {

			globalVar.PlayerHealth -= 1;
		};
		AddChild(timer);

		// Card Example
		Card testCard = new Card("Test Card", 0, "", "Test Text", () => { GetNode<GlobalVariables>("/root/GlobalVariables").EnemyHealth -= 5; });
		testCard.Activate();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}
}
