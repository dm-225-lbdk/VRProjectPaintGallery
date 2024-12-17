using Godot;

public partial class PlayerArea3D : Area3D
{
    protected bool PlayerInArea { get; private set; } = false;
    private const string PlayerName = "Player";

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        BodyExited += OnBodyExited;
    }

    private void OnBodyEntered(Node3D body)
    {
        if (body.Name == PlayerName)
        {
            PlayerInArea = true;
            OnPlayerEnter();
        }
    }

    private void OnBodyExited(Node3D body)
    {
        if (body.Name == PlayerName)
        {
            PlayerInArea = false;
            OnPlayerExit();
        }
    }
    protected virtual void OnPlayerEnter(){}

    protected virtual void OnPlayerExit(){}
}
