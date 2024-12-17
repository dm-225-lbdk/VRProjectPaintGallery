using Godot;

public partial class CantoPicture : PlayerArea3D
{
    private GpuParticles3D _particles;
    private AudioStreamPlayer _audio;

    public override void _Ready()
    {
        base._Ready();
        _audio = GetNodeOrNull<AudioStreamPlayer>("AudioStreamPlayer");
        _particles = GetNodeOrNull<GpuParticles3D>("GPUParticles3D");
    }

    public override void _Input(InputEvent @event)
    {
        if (PlayerInArea && @event.IsActionPressed("activate"))
            ToggleMode();
    }

    private void ToggleMode()
    {
        if (!_particles.Emitting && Global.Instance.GlobalValue < 15)
            return;

        if (!_particles.Emitting){
            Global.Instance.GlobalValue -= 15;
        }
        else{
            Global.Instance.GlobalValue += 10;
        }

        _particles.Emitting = !_particles.Emitting;
        _audio.Playing = !_audio.Playing;
    }
}
