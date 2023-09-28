namespace Controllers.Controllable
{
    public class Humanoid : ControllableAxis
    { 
        protected override void RunManual()
        {
            Agent.velocity = TargetDirection * Agent.speed;
        }
    }
}
