public partial class Character : Resource
{
    //Values for each character

    public int health{ get; set; }
    public GlobalVariables.AffinityType affinity { get; set; }
    public string playerDescription {  get; set; }
    public int EnergyMax {  get; set; }
    public string? PlayerImage { get; set; }

    public Character(int Heath,GlobalVariables.AffinityType Affinity,string PlayerDescription,int energyMax,string playerImage) 
    {
        health = Heath;
        affinity = Affinity;
        playerDescription = PlayerDescription;
        EnergyMax=energyMax;
        PlayerImage = playerImage;
    
    }



    

    
}