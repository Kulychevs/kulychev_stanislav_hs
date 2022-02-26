namespace HotSiberiansTest
{
    public sealed class Initializer
    {
        private readonly IInitalize[] _initalizes;

        public Initializer(IInitalize[] initalizes)
        {
            _initalizes = initalizes;
        }

        public void Init()
        {
            foreach (var item in _initalizes)
            {
                item.Initialize();
            }
        }

        public void Clear()
        {
            foreach (var item in _initalizes)
            {
                if (item is IClear clear)
                    clear.Clear();
            }
        }
    }
}
