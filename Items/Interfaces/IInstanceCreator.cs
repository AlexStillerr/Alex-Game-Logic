namespace AGL.Items
{
    public interface IInstanceCreator<out T>
    {
        T CreateInstance();
    }
}
