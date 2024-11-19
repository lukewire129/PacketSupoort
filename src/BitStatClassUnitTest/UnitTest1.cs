using BitSupport.SourceGenerators.Attributes;

namespace BitStatClassUnitTest
{
    [BitSupportFlags]
    public enum CharacterState
    {
        Idle = 0,
        Running = 1 << 0,
        Jumping = 1 << 1,
        Attacking = 1 << 2,
        Defending = 1 << 3
    }

    [BitState (typeof (CharacterStateFlags))]
    public partial class Character
    {

    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Character character = new Character ();
        }
    }
}