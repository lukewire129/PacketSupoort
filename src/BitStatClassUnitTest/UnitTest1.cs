using BitSupport.SourceGenerators.Attributes;

namespace BitStatClassUnitTest
{
    [Flags]
    public enum CharacterState1
    {
        Idle = 0,
        Running = 1 << 0,
        Jumping = 1 << 1,
        Attacking = 1 << 2,
        Defending = 1 << 3
    }
    [BitSupportFlags]
    public enum CharacterState2
    {
        Idle,
        Running,
        Jumping,
        Attacking,
        Defending,
    }

    [BitState (typeof (CharacterState2Flags))]
    public partial class Character
    {

    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Character character = new Character ();
            character.SetState(CharacterState2Flags.Idle);
        }
    }
}