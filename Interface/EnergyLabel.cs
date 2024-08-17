public partial class EnergyLabel : Label {

	public override void _Ready() {

		GlobalVariables.Current.PlayerEnergy_Updated += TextUpdate;
		GlobalVariables.Current.PlayerMaxEnergy_Updated += TextUpdate;
	}

	void TextUpdate(int value) {

		Text = $"{GlobalVariables.Current.PlayerEnergy} / {GlobalVariables.Current.PlayerMaxEnergy}";
	}
}