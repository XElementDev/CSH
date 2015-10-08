namespace XElement.DesignPatterns.CreationalPatterns.FactoryMethod
{
    public interface IFactory<TIn, TOut>
    {
        TOut Get( TIn param );
    }
}
