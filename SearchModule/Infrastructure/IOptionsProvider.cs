namespace SearchModule.Infrastructure
{
    interface IOptionsProvider<T>
    {
        T GetOptions();
    }

    class OptionsProvider<T> : IOptionsProvider<T>
    {
        readonly private T _options;
        public OptionsProvider(T options)
        {
            _options = options;
        }
        public T GetOptions()
        {
            return _options;
        }
    }
}
