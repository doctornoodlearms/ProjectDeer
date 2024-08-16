///<summary>
/// Common variables used across the project
///</summary>
///<remarks>
/// Example: Allows us to check the player health from any Node.
///</remarks>
public partial class GlobalVariables : Node {

	// UI Explanation
	// 1. Update variable from any node
	// 2. Variable emits a signal that it was updated
	// 3. Any node listening for the signal updates itself
	// See TestPlayer for example 

	[Signal] public delegate void PlayerHealth_UpdatedEventHandler(int value);
	[Signal] public delegate void PlayerMaxHealth_UpdatedEventHandler(int value);
	[Signal] public delegate void EnemyHealth_UpdatedEventHandler(int value);
	[Signal] public delegate void EnemyMaxHealth_UpdatedEventHandler(int value);

	int playerHealth;
	int playerMaxHealth;
	int enemyHealth;
	int enemyMaxHealth;

	public int PlayerHealth {
		get => playerHealth;
		set {
			playerHealth = value;
			EmitSignal(SignalName.PlayerHealth_Updated, value);
		}
	}
	public int PlayerMaxHealth {
		get => playerMaxHealth;
		set {
			playerMaxHealth = value;
			EmitSignal(SignalName.PlayerMaxHealth_Updated, value);
		}
	}

	public int EnemyHealth {

		get => enemyHealth;
		set {
			enemyHealth = value;
			EmitSignal(SignalName.EnemyHealth_Updated, value);
		}
	}
	public int EnemyMaxHealth {

		get => enemyMaxHealth;
		set {
			enemyMaxHealth = value;
			EmitSignal(SignalName.EnemyMaxHealth_Updated, value);
		}
	}


	public override void _Ready() {

		// Get inital status of private health values from Node instances

		BaseCharacter player = GetTree().GetFirstNodeInGroup("Player") as BaseCharacter;
		BaseCharacter enemy = GetTree().GetFirstNodeInGroup("Enemy") as BaseCharacter;

		playerHealth = player.Health;
		playerMaxHealth = player.MaxHealth;

		enemyHealth = enemy.Health;
		enemyMaxHealth = enemy.MaxHealth;

		Logging.Print("Version " + (string)ProjectSettings.GetSetting("application/config/version"));
	}

	// Not sure where else to put this right now
	public override void _Input(InputEvent @event) {

		// Allows closing of the game from any scene
		if (Input.IsActionJustPressed("ui_cancel")) GetTree().Quit();
		base._Input(@event);
	}
}