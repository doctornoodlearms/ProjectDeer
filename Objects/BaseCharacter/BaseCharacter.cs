

public partial class BaseCharacter : Control {

	enum CharacterType {
		CHARACTER_PLAYER,
		CHARACTER_ENEMY
	}

	[Export] CharacterType characterType;

	int health;
	int maxHealth;
	Texture2D sprite;

	PackedScene buffScene = GD.Load<PackedScene>("res://Objects/BuffScene/BuffScene.tscn");

	[ExportGroup("Node Paths")]
	[Export] public ProgressBar healthNode;
	[Export] public Sprite2D spriteNode;
	[Export] public HBoxContainer currentBuffs;

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

		switch (characterType) {

			case CharacterType.CHARACTER_PLAYER:
				BuffController.Current.PlayerBuff_Added += onBuffAdded;
				BuffController.Current.PlayerBuff_Removed += onBuffRemoved;
				BuffController.Current.PlayerBuff_StackUpdate += onBuffUpdate;
				break;

			case CharacterType.CHARACTER_ENEMY:
				BuffController.Current.EnemyBuff_Added += onBuffAdded;
				BuffController.Current.EnemyBuff_Removed += onBuffRemoved;
				BuffController.Current.EnemyBuff_StackUpdate += onBuffUpdate;
				break;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

	}

	void onBuffAdded(Buff newBuff) {

		BuffScene newBuffScene = buffScene.Instantiate<BuffScene>();
		newBuffScene.UpdateBuff(newBuff);
		currentBuffs.AddChild(newBuffScene);
	}
	void onBuffRemoved(Buff newBuff) {

		foreach (BuffScene buffScene in currentBuffs.GetChildren()) {

			if (buffScene.BuffId != newBuff.BuffId) continue;
			buffScene.QueueFree();
		}
	}
	void onBuffUpdate(Buff newBuff) {

		foreach (BuffScene buffScene in currentBuffs.GetChildren()) {

			if (buffScene.BuffId != newBuff.BuffId) continue;
			buffScene.BuffStacks = newBuff.Stacks;
		}
	}
}
