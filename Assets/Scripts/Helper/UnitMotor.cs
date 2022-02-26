namespace HotSiberiansTest
{
    public sealed class UnitMotor
    {
        private const float MAX_RANGE = 0.15f;

        public bool Move(PlayerModel model, PlayerView view)
        {
            var speedVector = (model.Destination - model.Position).normalized * model.GetSpeed;
            model.Position += speedVector * UnityEngine.Time.deltaTime;

            if ((model.Destination - model.Position).sqrMagnitude > MAX_RANGE * MAX_RANGE)
            {
                view.SetPosition(model.Position);
                return true;
            }

            return false;
        }
    }
}
