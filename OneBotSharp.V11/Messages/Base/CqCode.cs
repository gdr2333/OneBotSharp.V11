namespace OneBotSharp.V11.Messages.Base;

internal record struct CqCode(string Type, Dictionary<string, string> Payload);
