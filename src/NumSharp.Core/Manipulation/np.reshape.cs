﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NumSharp
{
    public static partial class np
    {
        public static NDArray reshape(NDArray nd, params int[] shape)
        {
            return nd.reshape(shape);
        }
    }
}
