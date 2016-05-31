namespace Casino
{
    public interface ICubesFactory
    {
        ICube NextCube();

        ICube NextCube(ICube current);
    }
}