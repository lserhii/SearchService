namespace SearchModule.Infrastructure
{
    interface IOptionsProvider<T>
    {
        T GetOptions();
    }
}
