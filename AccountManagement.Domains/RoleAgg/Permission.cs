﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public long Id { get; private set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public Permission(int code)
        {
            Code = code;
        }
        public Permission()
        {

        }
        public Permission(int code, string name)
        {
            Name = name;
            Code = code;
        }
    }
}
