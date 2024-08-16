public partial class TestEnemy : BaseCharacter {

	public override void _Ready() {

		GetNode<GlobalVariables>("/root/GlobalVariables").EnemyHealth_Updated += (int value) => Health = value;
		GetNode<GlobalVariables>("/root/GlobalVariables").EnemyMaxHealth_Updated += (int value) => MaxHealth = value;

		Logging.Print("Ready");

		base._Ready();
	}
}