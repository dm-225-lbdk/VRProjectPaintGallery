using Godot;

public partial class patch : PlayerArea3D
{
    private RandomNumberGenerator _rng = new();

    public override void _Ready()
    {
        base._Ready();
        SetRandomColorAndRotation();
    }

    public override void _Input(InputEvent @event)
    {
        if (PlayerInArea && @event.IsActionPressed("activate"))
        {
            Global.Instance.GlobalValue += 20;
            GetParent()?.QueueFree();
        }
    }

    private void SetRandomColorAndRotation()
    {
        var _sprite = GetParent()?.GetNode<Sprite3D>("Patch");
        if (_sprite != null)
        {
            Color randomColor = new Color(
                _rng.RandfRange(0.0f, 1.0f),
                _rng.RandfRange(0.0f, 1.0f),
                _rng.RandfRange(0.0f, 1.0f)
            );

            _sprite.Modulate = randomColor;

            _sprite.RotationDegrees = new Vector3(
                _sprite.RotationDegrees.X,
                _rng.RandfRange(0, 360),
                _sprite.RotationDegrees.Z
            );
        }
		Global.Instance.GlobalValue++;
    }
}
