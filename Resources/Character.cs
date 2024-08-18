using System.Threading.Channels;
using Godot.Collections;

public partial class Character : Resource {
	//Values for each character

	public int Health { get; set; }
	public GlobalVariables.AffinityType Affinity { get; set; }
	public string PlayerDescription { get; set; }
	public int EnergyMax { get; set; }
	public string? PlayerImage { get; set; }
	public Array<Card> cardList;

	public Character(int health, string playerDescription, int energyMax, Array<Card> newCards, GlobalVariables.AffinityType affinity = GlobalVariables.AffinityType.AFFINITY_NONE, string playerImage = "") {
		Health = health;
		Affinity = affinity;
		PlayerDescription = playerDescription;
		EnergyMax = energyMax;
		PlayerImage = playerImage;
		cardList = newCards;
	}
}