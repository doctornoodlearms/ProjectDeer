

using System.Reflection.Metadata.Ecma335;

public partial class BaseCharacter : Control {

	[Export] public int Health { get => (int)healthNode.Value; set => healthNode.Value = value; }
	[Export] public int MaxHealth { get => (int)healthNode.MaxValue; set => healthNode.MaxValue = value; }
	[Export] public Texture2D Sprite { get => spriteNode.Texture; set => spriteNode.Texture = value; }

	[ExportGroup("Node Paths")]
	[Export] ProgressBar healthNode;
	[Export] Sprite2D spriteNode;

	public override void _Ready() {
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}
}
