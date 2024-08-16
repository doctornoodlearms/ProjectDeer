public partial class TestPlayer : BaseCharacter {

	public override void _Ready() {

		GetNode<GlobalVariables>("/root/GlobalVariables").PlayerHealth_Updated += (int value) => Health = value;
		GetNode<GlobalVariables>("/root/GlobalVariables").PlayerMaxHealth_Updated += (int value) => MaxHealth = value;

		base._Ready();
	}
}