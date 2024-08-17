public partial class Nonsense : Button {

	public override void _Pressed() {

		DeckController.Current.DrawCard();
	}
}