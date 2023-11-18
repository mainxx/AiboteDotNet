﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiboteDotNet.AndroidBot.Api
{
    public interface IScreenSize
    {
        public Task<(int width, int height)> GetWindowSize();
    }
}
