﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.ViewModels.UI
{
    public interface IDispatcherHelper
    {
        void CheckBeginInvokeOnUi(Action action);
    }
}
