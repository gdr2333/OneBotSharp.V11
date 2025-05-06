using OneBotSharp.V11.Message.Base;

namespace OneBotSharp.V11.Message.Payload;

// 这个接口存在的意义只是怕我忘写东西
internal interface IPayload<TSelf>
    where TSelf : struct
{
    public abstract static TSelf Create(CqCode code);
}
