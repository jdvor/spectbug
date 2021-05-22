namespace spectbug
{
    public interface IFooService
    {
        string GetFoo();
    }

    public sealed class FooService : IFooService
    {
        public string GetFoo()
        {
            return "Foo!";
        }
    }
}
