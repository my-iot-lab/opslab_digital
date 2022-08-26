﻿namespace Admin.NET.Core.Service
{
    /// <summary>
    /// 定时任务方法
    /// </summary>
    [NotTable]
    public class TimerMethod : SysTimer
    {
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 所属类
        /// </summary>
        public Type DeclaringType { get; set; }
    }
}