public partial class BaseCard : Node {

	// TODO
	// What the fuck should affinity be???

	[ExportGroup("Values")]
	[Export] public string CardName { get => nameNode.Text; set => nameNode.Text = value; }
	[Export] public string CardText { get => cardTextNode.Text; set => cardTextNode.Text = value; }
	[Export] public Texture2D Image { get => imageNode.Texture; set => imageNode.Texture = value; }
	[Export] public int Cost { get => int.Parse(costNode.Text); set => costNode.Text = value.ToString(); }

	[ExportGroup("Node Paths")]
	[Export] Label nameNode;
	[Export] Label costNode;
	[Export] TextureRect imageNode;
	[Export] TextEdit cardTextNode;




	public override void _Ready() {


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}
}
