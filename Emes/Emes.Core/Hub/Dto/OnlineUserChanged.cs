namespace Emes.Core;

public class OnlineUserChangedDto
{
    public string Name { get; set; }

    public bool Offline { get; set; }

    public List<SysOnlineUser> List { get; set; }
}