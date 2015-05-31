﻿using System;

namespace Bob.Extensions.MsBuild
{
    public class MsBuildCompileCommand
    {
        public ITask Execute(Action<MsBuildCompileParameters> parameters)
        {
            return new MsBuildCompileTask(() =>
            {
                MsBuildCompileParameters instance = new MsBuildCompileParameters
                {
                };

                parameters(instance);
                return instance;
            });
        }
    }
}
