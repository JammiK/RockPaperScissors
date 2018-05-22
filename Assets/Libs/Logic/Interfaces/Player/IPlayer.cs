namespace Assets.Libs.Logic.Interfaces.Player
{
    public interface IPlayer
    {
        int Score { get; }
		StepType LastStep { get; }

        void Win();
        StepType NextStep();
    }
}