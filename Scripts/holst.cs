using Godot;

public partial class holst : Node3D
{
    private MeshInstance3D meshInstance;
    private SubViewport subViewport;

    public override void _Ready()
    {
        meshInstance = GetNode<MeshInstance3D>("MeshInstance3D");
        subViewport = GetNode<SubViewport>("MeshInstance3D/SubViewport");

        StandardMaterial3D material = (StandardMaterial3D)meshInstance.GetSurfaceOverrideMaterial(0);
        material.AlbedoTexture = subViewport.GetTexture();
    }
}
