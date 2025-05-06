namespace OneBotSharp.V11.Message.Base;

internal record struct CqCode(string Type, Dictionary<string, string> Payload);
