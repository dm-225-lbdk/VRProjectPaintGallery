using Godot;
using System;

public partial class Draw : Node2D
{
    private Node2D _lines;
    private bool _pressed = false;
    private Line2D _currentLine = null;

    public override void _Ready()
    {
        _lines = GetNode<Node2D>("Line2D");
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButtonEvent)
        {
            if (mouseButtonEvent.ButtonIndex == MouseButton.Left)
            {
                _pressed = mouseButtonEvent.Pressed;

                if (_pressed)
                {
                    _currentLine = new Line2D();
                    _currentLine.DefaultColor = Colors.Blue;
                    _currentLine.Width = 4;
                    _lines.AddChild(_currentLine);
                    _currentLine.AddPoint(mouseButtonEvent.Position);
                }
            }
        }
        else if (@event is InputEventMouseMotion mouseMotionEvent && _pressed)
        {
            _currentLine.AddPoint(mouseMotionEvent.Position);
        }
    }
}
