public partial class Buff : Resource {

	string buffId;
	int stacks;
	string buffName;
	string buffDescription;
	bool decayEnabled;

	public string BuffId { get => buffId; set => buffId = value; }
	public int Stacks { get => stacks; set => stacks = value; }
	public string BuffName { get => buffName; set => buffName = value; }
	public string BuffDescription { get => buffDescription; set => buffDescription = value; }
	public bool DecayEnabled { get => decayEnabled; set => decayEnabled = value; }

	public Buff(string newId, string newName, string newDescription, int newStacks, bool newDecay = true) {

		BuffId = newId;
		Stacks = newStacks;
		BuffName = newName;
		BuffDescription = newDescription;
		DecayEnabled = newDecay;
	}

	public override string ToString() {

		return $"{BuffName}: {Stacks}";
	}
}