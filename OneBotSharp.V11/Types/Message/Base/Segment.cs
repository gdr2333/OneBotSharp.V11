using OneBotSharp.V11.Types.Message.Payload;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OneBotSharp.V11.Types.Message.Base;

/// <summary>
/// 消息段基类
/// </summary>
public abstract class Segment
{
    /// <summary>
    /// 消息段类型
    /// </summary>
    public abstract string Type { get; }

    /// <summary>
    /// 消息段data内容（JSON）
    /// </summary>
    public abstract JsonNode Payload { get; }

    internal static Segment AutoInit(JsonNode data)
    {
        var typ = data["type"];
        var dat = data["data"];
        if (typ is not null && dat is not null)
            switch (typ.GetValue<string>())
            {
                case null:
                    throw new ArgumentNullException($"{nameof(data)}：JSON NULL！");
                case "text":
                    return new TextSegment(dat.GetValue<TextPayload>(), dat);
                case "face":
                    return new FaceSegment(dat.GetValue<IdOnlyPayload>(), dat);
                case "image":
                    return new ImageSegment(dat.GetValue<ImagePayload>(), dat);
                case "record":
                    return new RecordSegment(dat.GetValue<RecordPayload>(), dat);
                case "video":
                    return new VideoSegment(dat.GetValue<VideoPayload>(), dat);
                case "at":
                    return new AtSegment(dat.GetValue<AtPayload>(), dat);
                case "rps":
                    return new RpsSegment(dat);
                case "dice":
                    return new DiceSegment(dat);
                case "shake":
                    return new ShakeSegment(dat);
                case "poke":
                    return new PokeSegment(dat.GetValue<PokePayload>(), dat);
                /*
                 * 这个消息段应该收不到，如果真的有实现这么做了：
                 * 1. 这不符合标准，也就是说不在我们的目标范围内
                 * 2. 这需要更改上报的匿名状态，而我们目前不打算这么做
                case "anonymous":
                    return new AnonymousSegment(false);
                */
                case "share":
                    return new ShareSegment(dat.GetValue<SharePayload>(), dat);
                case "contact":
                    var contactPayload = dat.GetValue<ContactPayload>();
                    return contactPayload.Type switch
                    {
                        "qq" => new ContactQqSegment(contactPayload, dat),
                        "group" => new ContactGroupSegment(contactPayload, dat),
                        _ => new UnknowContactSegment(contactPayload, dat),
                    };
                case "location":
                    return new LocationSegment(dat.GetValue<LocationPayload>(), dat);
                case "music":
                    var musicType = dat["type"]?.GetValue<string>();
                    if (musicType is not null)
                        if (musicType == "custom")
                            return new CostomMusicShareSegment(dat.GetValue<CustomMusicSharePayload>(), dat);
                        else
                        {
                            var musicPayload = dat.GetValue<MusicSharePayload>();
#pragma warning disable CS0618
                            return musicPayload.Type switch
                            {
                                "qq" => new QqMusicShareSegment(musicPayload, dat),
                                "163" => new NeteaseMusicShareSegment(musicPayload, dat),
                                // 标准是这么写的......
                                "xm" => new XiamiMusicShareSegment(musicPayload, dat),
                                _ => new UnknowMusicShareSegment(musicPayload, dat),
                            };
#pragma warning restore CS0618
                        }
                    else
                        throw new ArgumentException($"{nameof(data)}：Music消息段不包含Type！");
                case "reply":
                    return new ReplySegment(dat.GetValue<IdOnlyPayload>(), dat);
                case "forward":
                    return new ForwardSegment(dat.GetValue<IdOnlyPayload>(), dat);
                case "node":
                    return new CustomNodeSegment(dat.GetValue<CustomNodePayload>(), dat);
                case "xml":
                    return new XmlSegment(dat.GetValue<DataOnlyPayload>(), dat);
                case "json":
                    return new JsonSegment(dat.GetValue<DataOnlyPayload>(), dat);
                default:
                    return new UnknowSegment(typ.GetValue<string>(), dat);
            }
        else
            throw new ArgumentException($"{nameof(data)}：内容无效！");
    }

    internal static Segment AutoInit(CqCode data)
    {
        switch (data.Type)
        {
            case "text":
                return new TextSegment(TextPayload.Create(data), null);
            case "face":
                return new FaceSegment(IdOnlyPayload.Create(data), null);
            case "image":
                return new ImageSegment(ImagePayload.Create(data), null);
            case "record":
                return new RecordSegment(RecordPayload.Create(data), null);
            case "video":
                return new VideoSegment(VideoPayload.Create(data), null);
            case "at":
                return new AtSegment(AtPayload.Create(data), null);
            case "rps":
                return new RpsSegment(null);
            case "dice":
                return new DiceSegment(null);
            case "shake":
                return new ShakeSegment(null);
            case "poke":
                return new PokeSegment(PokePayload.Create(data), null);
            /*
             * 这个消息段应该收不到，如果真的有实现这么做了：
             * 1. 这不符合标准，也就是说不在我们的目标范围内
             * 2. 这需要更改上报的匿名状态，而我们目前不打算这么做
            case "anonymous":
                return new AnonymousSegment(false);
            */
            case "share":
                return new ShareSegment(SharePayload.Create(data), null);
            case "contact":
                var contactPayload = ContactPayload.Create(data);
                return contactPayload.Type switch
                {
                    "qq" => new ContactQqSegment(contactPayload, null),
                    "group" => new ContactGroupSegment(contactPayload, null),
                    _ => new UnknowContactSegment(contactPayload, null),
                };
            case "location":
                return new LocationSegment(LocationPayload.Create(data), null);
            case "music":
                if (data.Payload.TryGetValue("type", out var musicType))
                    if (musicType == "custom")
                        return new CostomMusicShareSegment(CustomMusicSharePayload.Create(data), null);
                    else
                    {
                        var musicPayload = MusicSharePayload.Create(data);
#pragma warning disable CS0618
                        return musicPayload.Type switch
                        {
                            "qq" => new QqMusicShareSegment(musicPayload, null),
                            "163" => new NeteaseMusicShareSegment(musicPayload, null),
                            // 标准是这么写的......
                            "xm" => new XiamiMusicShareSegment(musicPayload, null),
                            _ => new UnknowMusicShareSegment(musicPayload, null),
                        };
#pragma warning restore CS0618
                    }
                else
                    throw new ArgumentException($"{nameof(data)}：Music消息段不包含Type！");
            case "reply":
                return new ReplySegment(IdOnlyPayload.Create(data), null);
            case "forward":
                return new ForwardSegment(IdOnlyPayload.Create(data), null);
            case "node":
                return new CustomNodeSegment(CustomNodePayload.Create(data), null);
                throw new NotImplementedException();
            case "xml":
                return new XmlSegment(DataOnlyPayload.Create(data), null);
            case "json":
                return new JsonSegment(DataOnlyPayload.Create(data), null);
            default:
                return new UnknowSegment(data);
        }
    }
}
