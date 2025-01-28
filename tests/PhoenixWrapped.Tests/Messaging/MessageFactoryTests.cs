using NFluent;
using PhoenixWrapped.Messaging;
using Xunit;

namespace PhoenixWrapped.Tests.Messaging;

public class MessageFactoryTests
{
    public static TheoryData<MessageType> MessageTypeValues()
    {
        var output = new TheoryData<MessageType>();
        foreach (var value in Enum.GetValues<MessageType>())
        {
            output.Add(value);
        }

        return output;
    }

    private readonly MessageFactory sut;

    public MessageFactoryTests()
    {
        sut = new MessageFactory();
    }
    
    [Theory]
    [MemberData(nameof(MessageTypeValues))]
    public void Mapping_Should_Contains_Every_Messages(MessageType messageType)
    {
        Check.That(sut.GetMappings()).ContainsKey(messageType);
    }
}