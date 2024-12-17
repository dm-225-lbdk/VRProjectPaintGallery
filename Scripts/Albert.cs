using Godot;

public partial class Albert : PlayerArea3D
{
    private AnimationPlayer areaAnimation;
    private AnimationPlayer clickAnimation;

    public override void _Ready()
    {
        base._Ready();
        areaAnimation = GetNodeOrNull<AnimationPlayer>("AreaAnimation");
        clickAnimation = GetNodeOrNull<AnimationPlayer>("ClickAnimation");
    }

    protected override void OnPlayerEnter()
    {
        areaAnimation?.Play("inArea");
    }

    protected override void OnPlayerExit()
    {
        areaAnimation?.Play("outArea");
    }

    public override void _Input(InputEvent @event)
    {
        if (PlayerInArea && @event.IsActionPressed("activate"))
        {
            Global.Instance.GlobalValue += 45;
            clickAnimation?.Play("click");
        }
    }
}
