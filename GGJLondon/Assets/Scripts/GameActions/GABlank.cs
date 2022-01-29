public class GABlank : GameAction
{
    public GABlank(int x, int y, Board board) : base(x, y, board) { }

    public override bool Redo()
    {
        return true;
    }

    public override void Undo()
    {
    }
}
