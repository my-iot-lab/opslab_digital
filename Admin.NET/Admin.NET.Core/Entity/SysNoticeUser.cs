﻿namespace Admin.NET.Core;

/// <summary>
/// 系统通知公告用户表
/// </summary>
[SugarTable("sys_notice_user", "通知公告用户表")]
public class SysNoticeUser
{
    /// <summary>
    /// 通知公告Id
    /// </summary>
    [SugarColumn(ColumnDescription = "通知公告Id")]
    public long NoticeId { get; set; }

    /// <summary>
    /// 用户Id
    /// </summary>
    [SugarColumn(ColumnDescription = "用户Id")]
    public long UserId { get; set; }

    /// <summary>
    /// 阅读时间
    /// </summary>
    [SugarColumn(ColumnDescription = "阅读时间")]
    public DateTime ReadTime { get; set; }

    /// <summary>
    /// 状态（字典 0未读 1已读）
    /// </summary>
    [SugarColumn(ColumnDescription = "状态（字典 0未读 1已读）")]
    public NoticeUserStatusEnum ReadStatus { get; set; }
}