namespace OneBotSharp.V11.Types.Message.Base;

internal record struct CqCode(string Type, Dictionary<string, string> Payload);
