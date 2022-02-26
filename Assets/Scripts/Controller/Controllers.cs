namespace HotSiberiansTest
{
    public sealed class Controllers
    {
        #region Fields

        private readonly IExecute[] _executeControllers;

        #endregion


        #region Properties

        public int Length => _executeControllers.Length;
        public IExecute this[int index] => _executeControllers[index];

        #endregion


        #region ClassLyfeCycles

        public Controllers(GameSettings settings)
        {
            var mapController = new MapController(settings.MapData);
            var playerController = new PlayerController(settings.PlayerData, mapController);
            var uiController = new UIController();

            _executeControllers = new IExecute[]
            {
                playerController
            };

            var initializes = new IInitalize[]
            {
                mapController,
                playerController
            };

            var initializer = new Initializer(initializes);

            uiController.OnStartGame += initializer.Init;
            uiController.OnClose += initializer.Clear;
            uiController.OnIdle += playerController.Idle;
            uiController.OnPatrol += playerController.Patrol;
            uiController.OnToBase += playerController.ToBase;

            playerController.OnHPChanged += uiController.SetNormalizedHP;
        }

        #endregion
    }
}

