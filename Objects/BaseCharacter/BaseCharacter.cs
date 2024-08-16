

public partial class BaseCharacter : Control {

	int health;
	int maxHealth;
	Texture2D sprite;

	[ExportGroup("Node Paths")]
	[Export] public ProgressBar healthNode;
	[Export] public Sprite2D spriteNode;

	// For some reason something is setting these before the nodes have been assigned
	[ExportGroup("Variables")]
	[Export]
	public int Health {
		get => health;
		set {
			health = value;
			healthNode.Value = value;
		}
	}
	[Export]
	public int MaxHealth {
		get => maxHealth;
		set {
			maxHealth = value;
			healthNode.MaxValue = value;
		}
	}
	[Export]
	public Texture2D Sprite {
		get => sprite;
		set {
			sprite = value;
			spriteNode.Texture = value;
		}
	}

	public override void _EnterTree() {

		base._EnterTree();
	}

	public override void _Ready() {

		healthNode.MaxValue = maxHealth;
		healthNode.Value = health;
		spriteNode.Texture = sprite;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}
}
