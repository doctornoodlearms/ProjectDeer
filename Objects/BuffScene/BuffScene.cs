public partial class BuffScene : Control {

	string buffName;
	string buffId;
	string buffDescription;
	int buffStacks;

	public int BuffStacks {

		get => buffStacks;
		set {
			if (GetNode<Label>("Stacks") == null) return;
			buffStacks = value;
			GetNode<Label>("Stacks").Text = value.ToString();
		}
	}
	public string BuffId { get => buffId; }

	public override void _Ready() {

		GetNode<Label>("Name").Text = buffName;
		GetNode<Label>("Stacks").Text = buffStacks.ToString();
		TooltipText = buffDescription;
	}
	public void UpdateBuff(Buff newBuff) {

		buffName = newBuff.BuffName;
		buffId = newBuff.BuffId;
		buffDescription = newBuff.BuffDescription;
		buffStacks = newBuff.Stacks;
	}
}