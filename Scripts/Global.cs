using Godot;

public partial class Global : Node
{
    public int GlobalValue = 0;
    public static Global Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }
}
