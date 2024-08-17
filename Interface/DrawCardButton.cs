public partial class DrawCardButton : Button {

	public override void _Pressed() {

		DeckController.Current.DrawCard();
	}
}