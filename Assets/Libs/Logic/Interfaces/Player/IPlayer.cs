namespace Assets.Libs.Logic.Interfaces.Player
{
    public interface IPlayer : IHaveScore
    {
        StepType NextStep();
        StepType LastStep { get; }
    }
}