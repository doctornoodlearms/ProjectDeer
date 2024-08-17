public partial class BaseCardScene : Node {

	// TODO
	// What the fuck should affinity be???

	string cardName = "";
	string cardText = "";
	Texture2D image;
	int cost = 0;
	int cardHandIndex;

	public string CardName {
		get => cardName;
		set {
			cardName = value;
			if (nameNode == null) return;
			nameNode.Text = value;
		}
	}

	public string CardText {
		get => cardText;
		set {
			cardText = value;
			if (cardTextNode == null) return;
			cardTextNode.Text = value;
		}
	}
	public Texture2D Image {
		get => image;
		set {
			image = value;
			if (imageNode == null) return;
			imageNode.Texture = value;
		}
	}
	public int Cost {
		get => cost;
		set {
			cost = value;
			if (costNode == null) return;
			costNode.Text = value.ToString();
		}
	}
	public int CardHandIndex {
		get => cardHandIndex;
		set => cardHandIndex = value;
	}

	[ExportGroup("Node Paths")]
	[Export] Label nameNode;
	[Export] Label costNode;
	[Export] TextureRect imageNode;
	[Export] TextEdit cardTextNode;
	[Export] Button playCardNode;




	public override void _Ready() {

		nameNode.Text = cardName;
		costNode.Text = cost.ToString();
		// imageNode.Texture = image;
		cardTextNode.Text = cardText;
		playCardNode.Pressed += () => { DeckController.Current.ActivateCard(CardHandIndex); };
	}

	public void Discard() {

		DeckController.Current.DiscardActivate(cardHandIndex);
		DeckController.Current.RemoveCard(cardHandIndex);
		QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}
}
