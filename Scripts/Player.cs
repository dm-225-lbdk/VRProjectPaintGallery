using Godot;

public partial class Player : CharacterBody3D
{
    [Export] public float Speed = 10.0f;
    [Export] public float MouseSensitivity = 0.8f;

    private Node3D _cameraPivot;
    private float _verticalLookAngle = 0.0f;
    private MeshInstance3D _textMeshInstance;
    private TextMesh _textMesh;
    private float _timeElapsed = 0.0f;

    public override void _Ready()
    {
        _cameraPivot = GetNode<Node3D>("CameraPivot3D");
        _textMeshInstance = GetNode<MeshInstance3D>("CameraPivot3D/Text");

        if (_textMeshInstance.Mesh is TextMesh textMesh)
        {
            _textMesh = textMesh;
        }

        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            RotateY(-mouseMotion.Relative.X * MouseSensitivity * 0.01f);

            _verticalLookAngle -= mouseMotion.Relative.Y * MouseSensitivity;
            _verticalLookAngle = Mathf.Clamp(_verticalLookAngle, -90.0f, 90.0f);

            _cameraPivot.Rotation = new Vector3(Mathf.DegToRad(_verticalLookAngle), 0, 0);

            if (_textMesh != null)
            {
                _textMesh.Text = $"Score: {Global.Instance.GlobalValue}";
            }
        }

        if (@event is InputEventKey keyEvent && keyEvent.Pressed && keyEvent.Keycode == Key.Escape)
        {
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        UpdateColor((float)delta);

        Vector3 velocity = Velocity;

        Vector3 direction = Vector3.Zero;
        if (Input.IsActionPressed("move_forward"))
            direction -= Transform.Basis.Z;
        if (Input.IsActionPressed("move_backward"))
            direction += Transform.Basis.Z;
        if (Input.IsActionPressed("move_left"))
            direction -= Transform.Basis.X;
        if (Input.IsActionPressed("move_right"))
            direction += Transform.Basis.X;

        direction = direction.Normalized();

        velocity.X = direction.X * Speed;
        velocity.Z = direction.Z * Speed;

        if (!IsOnFloor())
        {
            velocity.Y -= 20.0f * (float)delta;
        }
        else
        {
            velocity.Y = 0;
            if (Input.IsActionJustPressed("jump"))
                velocity.Y = 10.0f;
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void UpdateColor(float delta)
    {
        if (_textMeshInstance == null)
            return;

        _timeElapsed += delta;

        float r = (Mathf.Sin(_timeElapsed) + 1) / 2.0f;
        float g = (Mathf.Sin(_timeElapsed + 2) + 1) / 2.0f;
        float b = (Mathf.Sin(_timeElapsed + 4) + 1) / 2.0f;

        Color newColor = new Color(r, g, b);
        _textMeshInstance.MaterialOverride = new StandardMaterial3D
        {
            AlbedoColor = newColor
        };
    }
}
