namespace app.infrastructure
{
  public class Stub
  {
    public static StubType with<StubType>() where StubType : new()
    {
      throw new System.NotImplementedException();
    }
  }
}