﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public class NeedsPermissionAttribute : Attribute
    {
        public int Permissions { get; set; }
        public NeedsPermissionAttribute(int permissions)
        {
            Permissions = permissions;
        }
    }
}
