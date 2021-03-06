﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHelper.Api.Core
{
    public enum EUserRole
    {
        Admin = 1,
        User = 2
    }

    public enum EFriendRequestFlag
    {
        None,
        Approved,
        Rejected,
        Blocked,
        Spam
    }

    public enum EFriendRequestDirection
    {
        ByMe = 1,
        ToMe = 2
    }

    public enum EMhTaskStatus
    {
        None,
        Done,
    }

    public enum EMhTaskVisibleType
    {
        Public = 1,
        Friend = 2,
        Private = 3
    }

    public enum EMhTaskState
    {
        Current = 1,
        Delete = 2,
        ReSchedule = 3
    }

    public enum EScheduleMhTaskType
    {
        None = 0,
        Daily = 1,
        Weekly = 7,
        Monthly = 30
    }

    public enum EFeedType
    {
        CreateNote = 1,
        CreateMhTask = 2
    }
}
