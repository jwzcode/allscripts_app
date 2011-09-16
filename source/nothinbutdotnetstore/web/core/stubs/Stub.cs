namespace nothinbutdotnetstore.web.core.stubs
{
    public class Stub
    {
         public static StubType With<StubType>() where StubType : new()
         {
             return new StubType();
         }
    }
}